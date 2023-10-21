using Lexicom.DependencyInjection.Primitives;
using Microsoft.EntityFrameworkCore;
using Mush.Server.Application.Database;
using Mush.Server.Application.Database.Entities;
using Mush.Server.Application.Exceptions;

namespace Mush.Server.Application.Services;
public interface IMatchService
{

}
public class MatchService : IMatchService
{
    private readonly IDbContextFactory<MushDbContext> _dbContextFactory;
    private readonly ITimeProvider _timeProvider;
    private readonly IPasscodeService _passcodeService;

    public MatchService(
        IDbContextFactory<MushDbContext> dbContextFactory,
        ITimeProvider timeProvider,
        IPasscodeService passcodeService)
    {
        _dbContextFactory = dbContextFactory;
        _timeProvider = timeProvider;
        _passcodeService = passcodeService;
    }

    /// <exception cref="NoDormantMatchException"/>
    public async Task HostMatchAsync(CancellationToken cancellationToken)
    {
        Match match = await GetNextDormantMatchAsync(cancellationToken);

        int newPasscode = await _passcodeService.GetNewPasscodeAsync(cancellationToken);

        match.Passcode = newPasscode;
    }

    /// <exception cref="NoDormantMatchException"/>
    public async Task<Match> GetNextDormantMatchAsync(CancellationToken cancellationToken)
    {
        await using var db = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        TimeSpan maximumInActiveTimeSpan = TimeSpan.FromMinutes(5);

        DateTimeOffset minimumActiveDateTimeOffset = _timeProvider.UtcNow.Add(-maximumInActiveTimeSpan);

        Match? dormantMatch = await db.Matches.FirstOrDefaultAsync(m => m.LastActiveDateTimeOffsetUtc < minimumActiveDateTimeOffset, cancellationToken);

        if (dormantMatch is null)
        {
            throw new NoDormantMatchException();
        }

        return dormantMatch;
    }
}

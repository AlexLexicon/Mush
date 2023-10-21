namespace Mush.Server.Application.Services;
public interface IPasscodeService
{
    Task<int> GetNewPasscodeAsync(CancellationToken cancellationToken);
}
public class PasscodeService
{
    public async Task<int> GetNewPasscodeAsync(CancellationToken cancellationToken)
    {

    }
}

namespace Mush.Server.Application.Database.Entities;
public class Match
{
    public Guid Id { get; set; }
    public DateTimeOffset LastActiveDateTimeOffsetUtc { get; set; }
    public int Passcode { get; set; }
}

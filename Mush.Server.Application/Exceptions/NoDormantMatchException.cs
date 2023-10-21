namespace Mush.Server.Application.Exceptions;
public class NoDormantMatchException : Exception
{
    public NoDormantMatchException() : base($"No matches are currently dormant.")
    {
    }
}

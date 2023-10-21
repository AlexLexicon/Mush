using Microsoft.Extensions.DependencyInjection;

namespace Mush.Client.Application.Extensions;
public static class MediatRServiceConfigurationExtensions
{
    public static void RegisterServicesFromClientApplication(this MediatRServiceConfiguration mediatRServiceConfiguration)
    {
        mediatRServiceConfiguration.RegisterServicesFromAssemblyContaining<AssemblyScanMarker>();
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace Mush.Client.Wpf.ViewModels.Extensions;
public static class MediatRServiceConfigurationExtensions
{
    public static void RegisterServicesFromViewModels(this MediatRServiceConfiguration mediatRServiceConfiguration)
    {
        mediatRServiceConfiguration.RegisterServicesFromAssemblyContaining<AssemblyScanMarker>();
    }
}

using Lexicom.DependencyInjection.Amenities.Extensions;
using Lexicom.Validation.Options.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Mush.Client.Application.Options;
using Mush.Client.Application.Validators;

namespace Mush.Client.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddClientApplication(this IServiceCollection services)
    {
        services
            .AddOptions<HttpClientMushApiOptions>()
            .BindConfiguration()
            .Validate()
            .ValidateOnStart();

        services.AddHttpClient(nameof(HttpClientMushApiOptions), (sp, c) =>
        {
            var options = sp.GetRequiredService<IOptions<HttpClientMushApiOptions>>();

            string? baseAddress = options.Value.BaseAddress;

            if (baseAddress is null)
            {
                throw HttpClientMushApiOptionsValidator.ToUnreachableException();
            }

            c.BaseAddress = new Uri(baseAddress);
        });
    }
}

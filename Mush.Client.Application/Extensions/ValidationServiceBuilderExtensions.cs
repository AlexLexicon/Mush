using Lexicom.Validation;
using Lexicom.Validation.Amenities.Extensions;
using Lexicom.Validation.Extensions;
using Mush.Server.Api.Contracts.Extensions;

namespace Mush.Client.Application.Extensions;
public static class ValidationServiceBuilderExtensions
{
    public static void AddClientApplication(this IValidationServiceBuilder builder)
    {
        builder.AddAmenities();
        builder.AddMushApiRuleSets();
        builder.AddValidators<AssemblyScanMarker>();
    }
}

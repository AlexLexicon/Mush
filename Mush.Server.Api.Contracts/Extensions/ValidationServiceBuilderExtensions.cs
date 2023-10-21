using Lexicom.Validation;
using Lexicom.Validation.Extensions;

namespace Mush.Server.Api.Contracts.Extensions;
public static class ValidationServiceBuilderExtensions
{
    public static void AddMushApiRuleSets(this IValidationServiceBuilder builder)
    {
        builder.AddRuleSets<AssemblyScanMarker>();
    }
}

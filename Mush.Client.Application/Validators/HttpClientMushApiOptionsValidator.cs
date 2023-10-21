using Lexicom.Validation.Amenities.RuleSets;
using Lexicom.Validation.Extensions;
using Lexicom.Validation.Options;
using Mush.Client.Application.Options;

namespace Mush.Client.Application.Validators;
public class HttpClientMushApiOptionsValidator : AbstractOptionsValidator<HttpClientMushApiOptions>
{
    public HttpClientMushApiOptionsValidator(RequiredRuleSet requiredRuleSet)
    {
        RuleFor(o => o.BaseAddress)
            .UseRuleSet(requiredRuleSet);
    }
}

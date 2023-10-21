using Lexicom.AspNetCore.Controllers.Amenities.Extensions;
using Lexicom.DependencyInjection.Primitives.Extensions;
using Lexicom.DependencyInjection.Primitives.For.AspNetCore.Controllers.Extensions;
using Lexicom.Logging.AspNetCore.Controllers.Extensions;
using Lexicom.Smtp.AspNetCore.Controllers.Extensions;
using Lexicom.Supports.AspNetCore.Controllers.Extensions;
using Lexicom.Swashbuckle.Extensions;
using Lexicom.Validation.Amenities.Extensions;
using Lexicom.Validation.Extensions;
using Lexicom.Validation.For.AspNetCore.Controllers.Extensions;
using Microsoft.EntityFrameworkCore;
using Mush.Server.Api;
using Mush.Server.Application.Database;
using Mush.Server.Application.Extensions;

/*
 * Mush.Server.Api
 */

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Lexicom(options =>
{
    options.AddAmenities(options =>
    {
        options.AddErrorResponseActionFilter();
        options.AddExceptionHandlingMiddleware();
#if DEBUG
        options.DebugExceptionHandlingMiddleware(e =>
        {

        });
#endif
        options.AddInvalidModelStateFactory();
    });
    options.AddSwaggerGen();
    options.AddValidation(options =>
    {
        options.AddAmenities();
        options.AddRequestBodyActionFilter();
        options.AddValidators<AssemblyScanMarker>();
        //options.AddMoviesApiRuleSets();
    });
    options.AddLogging();
    options.AddPrimitives(options =>
    {
        options.AddTimeProvider();
        options.AddGuidProvider();
    });
});

builder.Services.AddDbContextFactory<MushDbContext>(options =>
{
    string? cs = builder.Configuration.GetConnectionString("MushDb");

    options.UseSqlServer(cs);
});

builder.Services.AddMushApplication();

var app = builder.Build();

app.UseLexicomExceptionHandlingMiddleware();
app.UseLexicomLogging();
app.UseLexicomSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

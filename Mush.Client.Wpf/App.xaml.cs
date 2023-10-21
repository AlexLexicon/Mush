using Lexicom.Concentrate.Supports.Wpf.Extensions;
using Lexicom.Concentrate.Wpf.Amenities.Extensions;
using Lexicom.Concentrate.Wpf.Themes.Extensions;
using Lexicom.Configuration.Settings.For.Wpf.Extensions;
using Lexicom.Mvvm.Amenities.Extensions;
using Lexicom.Mvvm.Extensions;
using Lexicom.Mvvm.For.Wpf.Extensions;
using Lexicom.Supports.Wpf.Extensions;
using Lexicom.Validation.Extensions;
using Lexicom.Validation.For.Wpf.Extensions;
using Lexicom.Wpf.Amenities.Extensions;
using Lexicom.Wpf.DependencyInjection;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.Configuration;
using Mush.Client.Application.Extensions;
using Mush.Client.Wpf.ViewModels;
using Mush.Client.Wpf.ViewModels.Extensions;
using Mush.Client.Wpf.Views;

namespace Mush.Client.Wpf;
public partial class App : System.Windows.Application
{
    public App()
    {
        WpfApplicationBuilder builder = WpfApplication.CreateBuilder(this);

        builder.Configuration.AddJsonFile("appsettings.json");

        builder.Lexicom(options =>
        {
            options.AddSettings(Wpf.Properties.Settings.Default);
            options.AddAmenities();
            options.AddMvvm(options =>
            {
                options.AddViewModel<MainWindowViewModel>(options =>
                {
                    options.ForWindow<MainWindowView>();
                });

                //add mediatR must come after adding all view models
                options.AddMediatR(options =>
                {
                    options.NotificationPublisherType = typeof(TaskWhenAllPublisher);

                    options.RegisterServicesFromClientApplication();
                    options.RegisterServicesFromViewModels();
                });
            });
            options.AddValidation(options =>
            {
                options.AddValidators<AssemblyScanMarker>();
                options.AddClientApplication();
            });
            options.Concentrate(options =>
            {
                options.AddAmenities();
                options.AddTheming();
                options.AddClientAuthentication();
            });
        });

        builder.Services.AddClientApplication();

        WpfApplication app = builder.Build();

        app.StartupWindow<MainWindowView>();
    }
}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lexicom.Mvvm;
using System.Windows.Input;

namespace Mush.Client.Wpf.ViewModels;
public sealed partial class MainWindowViewModel : ObservableObject, IShowableViewModel
{
    public MainWindowViewModel()
    {

    }

    public ICommand? ShowCommand { private get; set; }

    [RelayCommand]
    private Task LoadedAsync()
    {
        ShowCommand?.Execute(null);

        return Task.CompletedTask;
    }
}

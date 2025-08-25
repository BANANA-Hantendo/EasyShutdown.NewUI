using EasyShutdown.NewUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace EasyShutdown.NewUI.Views;

public sealed partial class ShutdownDialogPage : Page
{
    public ShutdownDialogViewModel ViewModel
    {
        get;
    }

    public ShutdownDialogPage()
    {
        ViewModel = App.GetService<ShutdownDialogViewModel>();
        InitializeComponent();
    }
}

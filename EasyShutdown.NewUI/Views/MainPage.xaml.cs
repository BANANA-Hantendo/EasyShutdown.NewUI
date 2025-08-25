using EasyShutdown.NewUI.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace EasyShutdown.NewUI.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}

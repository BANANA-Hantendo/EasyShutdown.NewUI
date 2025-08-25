using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using EasyShutdown.NewUI.Contracts.Services;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace EasyShutdown.NewUI.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{
    [ObservableProperty]
    private bool isBackEnabled;
    private XamlRoot XamlRoot;

    public ICommand MenuFileExitCommand
    {
        get;
    }

    public ICommand MenuViewsShutdownDialogCommand
    {
        get;
    }

    public ICommand MenuSettingsCommand
    {
        get;
    }

    public ICommand MenuViewsShutdownCommand
    {
        get;
    }

    public ICommand MenuViewsRestartCommand
    {
        get;
    }

    public ICommand MenuViewsStopCommand
    {
        get;
    }

    public INavigationService NavigationService
    {
        get;
    }

    public ShellViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;

        MenuFileExitCommand = new RelayCommand(OnMenuFileExit);
        MenuViewsShutdownDialogCommand = new RelayCommand(OnMenuViewsShutdownDialog);
        MenuSettingsCommand = new RelayCommand(OnMenuSettings);
        MenuViewsShutdownCommand = new RelayCommand(OnMenuViewsShutdown);
        MenuViewsRestartCommand = new RelayCommand(OnMenuViewsRestart);
        MenuViewsStopCommand = new RelayCommand(OnMenuViewsStop);
    }

    private void OnNavigated(object sender, NavigationEventArgs e) => IsBackEnabled = NavigationService.CanGoBack;

    private void OnMenuFileExit() => Application.Current.Exit();

    private void OnMenuViewsShutdownDialog() => NavigationService.NavigateTo(typeof(ShutdownDialogViewModel).FullName!);

    private void OnMenuSettings() => NavigationService.NavigateTo(typeof(SettingsViewModel).FullName!);

    private async void ShowDialog_Click(object sender, RoutedEventArgs e)
    {
        ContentDialog dialog = new ContentDialog();

        // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
        dialog.XamlRoot = this.XamlRoot;
        dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
        dialog.Title = "本当にシャットダウンしてよろしいですか?";
        dialog.PrimaryButtonText = "はい";
        dialog.SecondaryButtonText = "いいえ";
        dialog.CloseButtonText = "キャンセル";
        dialog.DefaultButton = ContentDialogButton.Primary;
        dialog.Content = new ContentDialogContent();

        var result = await dialog.ShowAsync();
    }

    private async void ShowStopDialog_Click(object sender, RoutedEventArgs e)
    {
        ContentDialog dialog = new ContentDialog();

        // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
        dialog.XamlRoot = this.XamlRoot;
        dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
        dialog.Title = "本当に休止状態にしてよろしいですか?";
        dialog.PrimaryButtonText = "はい";
        dialog.SecondaryButtonText = "いいえ";
        dialog.CloseButtonText = "キャンセル";
        dialog.DefaultButton = ContentDialogButton.Primary;
        dialog.Content = new ContentDialogContent();

        var result = await dialog.ShowAsync();
    }

    private void OnMenuViewsShutdown() => ShowDialog_Click(null, null);

    private void OnMenuViewsRestart() => ShowDialog_Click(null, null);

    private void OnMenuViewsStop() => ShowStopDialog_Click(null, null);

}

internal class ContentDialogContent
{
    public ContentDialogContent()
    {
    }
}

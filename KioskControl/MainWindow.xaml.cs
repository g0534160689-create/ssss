using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Win32;
using KioskControl.Models;
using KioskControl.Services;
namespace KioskControl;
public partial class MainWindow : Window
{
    private readonly ConfigurationService _config = new();
    private readonly LauncherService _launcher = new();
    private readonly ObservableCollection<AllowedApp> _apps = new();
    public MainWindow()
    {
        InitializeComponent();
        AppsGrid.ItemsSource = _apps;
        Loaded += async (_, _) => { foreach (var app in await _config.LoadAsync()) _apps.Add(app); };
    }
    private void AddApp_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog { Title = "בחר קובץ הפעלה", Filter = "תוכנות Windows (*.exe)|*.exe", CheckFileExists = true };
        if (dialog.ShowDialog() != true) return;
        _apps.Add(new AllowedApp { Name = System.IO.Path.GetFileNameWithoutExtension(dialog.FileName), ExecutablePath = dialog.FileName, Enabled = true });
    }
    private async void Save_Click(object sender, RoutedEventArgs e)
    {
        try { AppsGrid.CommitEdit(); AppsGrid.CommitEdit(); await _config.SaveAsync(_apps); MessageBox.Show("ההגדרות נשמרו.", "KioskControl", MessageBoxButton.OK, MessageBoxImage.Information); }
        catch (Exception ex) { MessageBox.Show(ex.Message, "שגיאה בשמירה", MessageBoxButton.OK, MessageBoxImage.Error); }
    }
    private void Launch_Click(object sender, RoutedEventArgs e)
    {
        if (AppsGrid.SelectedItem is not AllowedApp app) { MessageBox.Show("בחר תוכנה תחילה."); return; }
        try { _launcher.Launch(app); } catch (Exception ex) { MessageBox.Show(ex.Message, "לא ניתן להפעיל", MessageBoxButton.OK, MessageBoxImage.Warning); }
    }
}

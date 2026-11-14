using System.Diagnostics;
using KioskControl.Models;
namespace KioskControl.Services;
public sealed class LauncherService
{
    public Process? Launch(AllowedApp app)
    {
        if (!app.Enabled) throw new InvalidOperationException("התוכנה אינה מאושרת להפעלה.");
        if (!File.Exists(app.ExecutablePath)) throw new FileNotFoundException("קובץ ההפעלה לא נמצא.", app.ExecutablePath);
        return Process.Start(new ProcessStartInfo { FileName = app.ExecutablePath, Arguments = app.Arguments, UseShellExecute = true, WorkingDirectory = Path.GetDirectoryName(app.ExecutablePath)! });
    }
}

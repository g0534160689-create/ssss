namespace KioskControl.Models;
public sealed class AllowedApp
{
    public string Name { get; set; } = "";
    public string ExecutablePath { get; set; } = "";
    public bool Enabled { get; set; } = true;
    public string Arguments { get; set; } = "";
}

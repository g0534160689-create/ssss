using System.Text.Json;
using KioskControl.Models;
namespace KioskControl.Services;
public sealed class ConfigurationService
{
    private readonly string _folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "KioskControl");
    private string FilePath => Path.Combine(_folder, "allowed-apps.json");
    public async Task<List<AllowedApp>> LoadAsync()
    {
        Directory.CreateDirectory(_folder);
        if (!File.Exists(FilePath)) return new();
        await using var stream = File.OpenRead(FilePath);
        return await JsonSerializer.DeserializeAsync<List<AllowedApp>>(stream) ?? new();
    }
    public async Task SaveAsync(IEnumerable<AllowedApp> apps)
    {
        Directory.CreateDirectory(_folder);
        await using var stream = File.Create(FilePath);
        await JsonSerializer.SerializeAsync(stream, apps, new JsonSerializerOptions { WriteIndented = true });
    }
}

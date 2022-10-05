namespace AppVersioning.API.DTO;

public class AppVersionDto
{
    public const string SETTINGS_KEY = "AppMinVersions";

    public string Key { get; set; } = string.Empty;
    public string MinVersion { get; set; } = string.Empty;
}

using System.ComponentModel.DataAnnotations;

namespace Loot.Shared.Settings;

public record EmailSettings
{
    public const string SectionName = "EmailSettings";
    
    [Required(AllowEmptyStrings = false)]
    public string From { get; set; } =  string.Empty;
    
    [Required(AllowEmptyStrings = false)]
    public string Host { get; set; } =  string.Empty;
    
    public int Port { get; set; }
    
    [Required(AllowEmptyStrings = false)]
    public string Username { get; set; } = string.Empty;
    
    [Required(AllowEmptyStrings = false)]
    public string Password { get; set; } = string.Empty;
}
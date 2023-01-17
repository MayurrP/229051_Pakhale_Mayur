namespace BOL;
using System.ComponentModel.DataAnnotations;
public class Player
{
    [Required]
    [Range(minimum:1,maximum:1000)]
    public int Playerid{get;set;}
    [Required]
    [StringLength(10)]
    public string? Name{get;set;}
    [Required]
    [StringLength(20)]
    public string? Sports{get;set;}
    [Required]
    [Range(minimum:1,maximum:1000)]
    public int Matches{get;set;}
}

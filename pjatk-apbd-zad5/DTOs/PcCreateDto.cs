using System.ComponentModel.DataAnnotations;

namespace pjatk_apbd_zad5.DTOs;

public class PcCreateDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
}

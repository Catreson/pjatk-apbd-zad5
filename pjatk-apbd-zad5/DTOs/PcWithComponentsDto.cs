namespace pjatk_apbd_zad5.DTOs;

public class PcWithComponentsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    public List<PcComponentItemDto> Components { get; set; } = [];
}

public class PcComponentItemDto
{
    public int Amount { get; set; }
    public ComponentDetailDto Component { get; set; } = null!;
}

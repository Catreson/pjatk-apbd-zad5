using pjatk_apbd_zad5.DTOs;

namespace pjatk_apbd_zad5.Services;

public interface IPcService
{
    Task<IEnumerable<PcGetAllDto>> GetAllPcsAsync();
    Task<PcWithComponentsDto> GetPcComponentsAsync(int id);
    Task<PcGetAllDto> CreatePcAsync(PcCreateDto dto);
    Task UpdatePcAsync(int id, PcUpdateDto dto);
    Task DeletePcAsync(int id);
}

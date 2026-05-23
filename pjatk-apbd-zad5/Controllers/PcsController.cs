using Microsoft.AspNetCore.Mvc;
using pjatk_apbd_zad5.DTOs;
using pjatk_apbd_zad5.Exceptions;
using pjatk_apbd_zad5.Services;

namespace pjatk_apbd_zad5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PcsController : ControllerBase
{
    private readonly IPcService _pcService;

    public PcsController(IPcService pcService)
    {
        _pcService = pcService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _pcService.GetAllPcsAsync());
    }

    [Route("{id}/components")]
    [HttpGet]
    public async Task<IActionResult> GetComponents(int id)
    {
        try
        {
            var components = await _pcService.GetPcComponentsAsync(id);
            return Ok(components);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(PcCreateDto dto)
    {
        var created = await _pcService.CreatePcAsync(dto);
        return Created($"api/pcs/{created.Id}", created);
    }

    [Route("{id}")]
    [HttpPut]
    public async Task<IActionResult> Update(int id, PcUpdateDto dto)
    {
        try
        {
            await _pcService.UpdatePcAsync(id, dto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _pcService.DeletePcAsync(id);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}

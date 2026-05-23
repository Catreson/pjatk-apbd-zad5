using Microsoft.EntityFrameworkCore;
using pjatk_apbd_zad5.Data;
using pjatk_apbd_zad5.DTOs;
using pjatk_apbd_zad5.Entities;
using pjatk_apbd_zad5.Exceptions;

namespace pjatk_apbd_zad5.Services;

public class PcService : IPcService
{
    private readonly AppDbContext _dbContext;

    public PcService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PcGetAllDto>> GetAllPcsAsync()
    {
        return await _dbContext.PCs
            .Select(pc => new PcGetAllDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            })
            .ToListAsync();
    }

    public async Task<PcWithComponentsDto> GetPcComponentsAsync(int id)
    {
        var pc = await _dbContext.PCs
            .Include(p => p.PCComponents)
                .ThenInclude(pc => pc.Component)
                    .ThenInclude(c => c.ComponentManufacturer)
            .Include(p => p.PCComponents)
                .ThenInclude(pc => pc.Component)
                    .ThenInclude(c => c.ComponentType)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pc == null)
            throw new NotFoundException($"PC with id {id} not found");

        return new PcWithComponentsDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock,
            Components = pc.PCComponents.Select(pc => new PcComponentItemDto
            {
                Amount = pc.Amount,
                Component = new ComponentDetailDto
                {
                    Code = pc.Component.Code,
                    Name = pc.Component.Name,
                    Description = pc.Component.Description,
                    Manufacturer = new ManufacturerDto
                    {
                        Id = pc.Component.ComponentManufacturer.Id,
                        Abbreviation = pc.Component.ComponentManufacturer.Abbreviation,
                        FullName = pc.Component.ComponentManufacturer.FullName,
                        FoundationDate = pc.Component.ComponentManufacturer.FoundationDate
                    },
                    Type = new ComponentTypeDto
                    {
                        Id = pc.Component.ComponentType.Id,
                        Abbreviation = pc.Component.ComponentType.Abbreviation,
                        Name = pc.Component.ComponentType.Name
                    }
                }
            }).ToList()
        };
    }

    public async Task<PcGetAllDto> CreatePcAsync(PcCreateDto dto)
    {
        var pc = new PC
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _dbContext.PCs.Add(pc);
        await _dbContext.SaveChangesAsync();

        return new PcGetAllDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task UpdatePcAsync(int id, PcUpdateDto dto)
    {
        var pc = await _dbContext.PCs.FindAsync(id);
        if (pc == null)
            throw new NotFoundException($"PC {id} was not found");

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePcAsync(int id)
    {
        var pc = await _dbContext.PCs.FindAsync(id);
        if (pc == null)
            throw new NotFoundException($"Could not find PC with id {id}");

        _dbContext.PCs.Remove(pc);
        await _dbContext.SaveChangesAsync();
    }
}

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zaiko.Models;
using Zaiko.Services.Common.DTO;
using Zaiko.Services.Sheets.DTO;

namespace Zaiko.Services
{
    public class SheetsService
    {
        Zaiko.Data.ZaikoDataContext _context;

        public SheetsService(Zaiko.Data.ZaikoDataContext context)
        {
            _context = context;
        }

        public async Task<SheetDTO> CreateSheet(CreateSheetDTO dto)
        {
            var sheet = new Sheet(dto.Name);
            await _context.SheetDbSet.AddAsync(sheet);
            await _context.SaveChangesAsync();
            return new SheetDTO(sheet);
        }

        public async Task<PagedQueryResponse<SheetDTO>> GetSheets(PagedQueryParams _params)
        {
            var skip = Math.Max((_params.Page - 1) * _params.PageSize, 0);
            var take = Math.Clamp(_params.PageSize, 1, 100);
            var result = await _context.SheetDbSet.AsQueryable().Skip(skip).Take(take).Select(s => new SheetDTO(s)).ToArrayAsync();
            var resultDto = new PagedQueryResponse<SheetDTO>
            {
                Items = result,
                Page = _params.Page,
                PageSize = _params.PageSize,
                TotalCount = result.Length
            };
            return resultDto;
        }

        public async Task<SheetDTO> UpdateSheet(UpdateSheetDTO dto)
        {
            var sheet = await _context.SheetDbSet.FindAsync(dto.Id);
            if (sheet == null) throw new System.Exception("SHEET_NOT_FOUND");
            sheet.Name = dto.Name;
            await _context.SaveChangesAsync();

            return new SheetDTO(sheet);
        }

        public async Task DeleteSheet(System.Guid Id)
        {
            var sheet = await _context.SheetDbSet.FindAsync(Id);
            if (sheet == null) throw new System.Exception("SHEET_NOT_FOUND");
            _context.SheetDbSet.Remove(sheet);
            await _context.SaveChangesAsync();
        }
    }
}
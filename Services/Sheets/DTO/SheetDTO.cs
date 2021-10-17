using System;
using System.Collections.Generic;
using System.Linq;
using Zaiko.Services.ProductListEntries.DTO;
using Zaiko.Models;

namespace Zaiko.Services.Sheets.DTO
{
    public record SheetDTO
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public IEnumerable<ProductListEntryDTO> Entries { get; init; }

        public SheetDTO(Sheet sheet)
        {
            Id = sheet.Id;
            Name = sheet.Name;
            Entries = sheet.GetProductList().Select(x => new ProductListEntryDTO(x));
        }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zaiko.Services;
using Zaiko.Services.Common.DTO;
using Zaiko.Services.Sheets.DTO;

namespace Zaiko.Controllers
{
    [ApiController]
    [Route("Sheets")]
    public class SheetsController : ControllerBase
    {
        private readonly SheetsService _sheetsService;

        public SheetsController(ILogger<SheetsController> logger, SheetsService sheetsService)
        {
            _sheetsService = sheetsService;
        }

        [HttpGet]
        public Task<PagedQueryResponse<SheetDTO>> Get([FromQuery(Name = "page")] string _page,
            [FromQuery(Name = "pageSize")] string _pageSize)
        {
            int.TryParse(_page, out var page);
            int.TryParse(_pageSize, out var pageSize);
            var queryParams = new PagedQueryParams
            {
                Page = page,
                PageSize = pageSize
            };
            return _sheetsService.GetSheets(queryParams);
        }

        [HttpPost]
        public Task<SheetDTO> Post([FromBody] CreateSheetDTO dto)
        {
            return _sheetsService.CreateSheet(dto);
        }

        [HttpPatch("{id}")]
        public Task<SheetDTO> Patch(Guid id, [FromBody] UpdateSheetDTO dto)
        {
            dto.Id = id;
            return _sheetsService.UpdateSheet(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _sheetsService.DeleteSheet(id);
            return new OkResult();
        }
    }
}
using System.Collections.Generic;

namespace Zaiko.Services.Common.DTO
{
    public class PagedQueryResponse<T> : PagedQueryParams
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
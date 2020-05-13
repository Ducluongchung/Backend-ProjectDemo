using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDocker.Domain.Dtos.Common
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { set; get; }
        public int TotalRecord { set; get; }
        public int PageCount { set; get; }
    }
}

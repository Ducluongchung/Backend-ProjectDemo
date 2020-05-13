using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDocker.Domain.Dtos
{
    public class ProductPagingRequest
    {
        public string KeyWord { get; set; }

        public int pageIndex { set; get; }

        public int pageSize { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDocker.Domain.Dtos
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SeoAlias { set; get; }

        public DateTime DateCreated { set; get; }

        public int Price { set; get; }
    }
}

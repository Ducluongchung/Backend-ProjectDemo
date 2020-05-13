using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDocker.Domain.Dtos
{
    public class ProductViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string SeoAlias { set; get; }

        public DateTime DateCreated { set; get; }

    }
}

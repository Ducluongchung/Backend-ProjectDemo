using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDocker.Domain.Data.Product
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public DateTime DateCreated { set; get; }

        public string SeoAlias { set; get; }

    }
}

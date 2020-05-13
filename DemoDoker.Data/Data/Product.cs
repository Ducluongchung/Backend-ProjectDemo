using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDoker.Data.Data
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime DateCreated { set; get; }

        public string SeoAlias { set; get; }

    }
}

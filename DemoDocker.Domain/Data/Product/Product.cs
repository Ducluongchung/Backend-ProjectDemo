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

        public void UpdateMetadata(string name, string description, int price, DateTime dateCreated, string seoAlias)
        {
            Name = name;
            Description = description;
            Price = price;
            DateCreated = dateCreated;
            SeoAlias = seoAlias;
        }

    }
}

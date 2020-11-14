using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetConfAPI.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Picture { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}

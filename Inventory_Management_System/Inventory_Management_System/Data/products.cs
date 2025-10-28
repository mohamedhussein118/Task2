using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Data
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; } 
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? SupplierID { get; set; }


        public Supplier? Supplier { get; set; }
    }
}

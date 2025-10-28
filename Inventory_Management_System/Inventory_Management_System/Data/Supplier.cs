using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Data
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string Name { get; set; } 
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}

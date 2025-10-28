using Inventory_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Inventory_Management_System
{
    /// <summary>
    /// Interaction logic for the_Product_Stock_Page.xaml
    /// </summary>
    public partial class the_Product_Stock_Page : Window
    {
        Context db = new Context();
        public the_Product_Stock_Page()
        {
            InitializeComponent();
            LoadStockData();
            lowstockdata();
        }

        public void LoadStockData()
        {
             var displayStock = from p in db.Products
                               
                               select new
                               {
                                   p.Name,
                                   p.Description,
                                   p.Price,
                                   p.Quantity,

                               };
            dataGridStock.ItemsSource = displayStock.ToList();

        }
        public void lowstockdata()
        {
            var displayStock = from p in db.Products
                               where p.Quantity < 10
                               select new
                               {
                                   p.Name,
                                   p.Description,
                                   p.Price,
                                   p.Quantity,
                               };
            Low.ItemsSource = displayStock.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtProductName.Text;
            string  quan= txtQuantity.Text;
            if (string.IsNullOrWhiteSpace(name) || int.Parse(quan )<= 0||string.IsNullOrEmpty(quan)  )
            {
                MessageBox.Show("Please enter valid product details.");
                return;
            }

            var search = db.Products.FirstOrDefault(p => p.Name == name);
            if(search.Quantity<int.Parse(quan))
            {
                 MessageBox.Show("Insufficient stock available.");
                return;
            }
            if (search != null ||search.Quantity>0)
            {
                search.Quantity -= int.Parse(quan);
                db.SaveChanges();
                MessageBox.Show("Product Ship Out successfully.");
                txtProductName.Clear();
                txtQuantity.Clear();
                LoadStockData();
                lowstockdata();
            }
            else
            {
                MessageBox.Show("Product Not Found.");
            }
            txtProductName.Clear();
            txtQuantity.Clear(); 
        }

    }
}

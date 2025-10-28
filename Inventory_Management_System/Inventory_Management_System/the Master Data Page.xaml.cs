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
    /// Interaction logic for the_Master_Data_Page.xaml
    /// </summary>
    public partial class the_Master_Data_Page : Window
    {
        Context db = new Context();
        public the_Master_Data_Page()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string name= txtsupplierName.Text;
            string phone= txtsupplierphone.Text;
            string Email=txtsupplierEmail .Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Please enter valid supplier details.");
                return;
            }
            Supplier newSupplier = new Supplier
            {
                Name = name,
                Phone = phone,
                Email = Email
            };
            db.Suppliers.Add(newSupplier);
            db.SaveChanges();
            MessageBox.Show("Supplier added successfully.");
            txtsupplierName.Clear();
            txtsupplierphone.Clear();
            txtsupplierEmail.Clear();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            string name= txtsupplierName.Text;
            string phone= txtsupplierphone.Text;
            string Email=txtsupplierEmail .Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Please enter valid supplier details.");
                return;
            }
            var searech = db.Suppliers.Find(name);
            if (searech != null)
            {
                searech.Phone = phone;
                searech.Email = Email;
                db.SaveChanges();
                MessageBox.Show("Supplier Edited successfully.");
            }
            else
            {
                MessageBox.Show("Supplier Not Found.");
            }
            txtsupplierName.Clear();
            txtsupplierphone.Clear();
            txtsupplierEmail.Clear();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            string productDescription = txtProductDescription.Text;
            string productPrice= (txtProductPrice.Text);
            string productQuantity = (txtProductQuantity.Text);
            string supplier = (txtSupplier.Text);
            if (string.IsNullOrWhiteSpace(productName) ||string.IsNullOrWhiteSpace(supplier) ||string.IsNullOrWhiteSpace(productDescription) || decimal.Parse( productPrice) <= 0 || int.Parse(productQuantity) <= 0)
            {
                MessageBox.Show("Please enter valid product details.");
                return;
            }
            var id=( from s in db.Suppliers
                    where s.Name==supplier
                    select s.SupplierID).FirstOrDefault();
            if (id == null)
            {
                MessageBox.Show("Supplier Not Found.");
                return;
            }
            Product newProduct = new Product
            {
                Name = productName,
                Description = productDescription,
                Price =decimal.Parse( productPrice),
                Quantity = int.Parse(productQuantity),
                SupplierID=id
               
            };
            db.Products.Add(newProduct);
            db.SaveChanges();
            MessageBox.Show("Product added successfully.");
            txtProductName.Clear();
            txtProductDescription.Clear();
            txtProductPrice.Clear();
            txtProductQuantity.Clear();
            txtSupplier.Clear();


        }

        private void btnEditProducts_Click(object sender, RoutedEventArgs e)
        {

            string productName = txtProductName.Text;
            
            if (string.IsNullOrWhiteSpace(productName) )
            {
                MessageBox.Show(@"To Edit Product U should Fill All The Fields But You cannot Change The Product ID And Its Name
","Error", MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            string productDescription = txtProductDescription.Text;
            decimal productPrice = decimal.Parse(txtProductPrice.Text);
            int productQuantity = int.Parse(txtProductQuantity.Text);
            string supplier = (txtSupplier.Text);
            if(string.IsNullOrEmpty(productDescription)||(string.IsNullOrEmpty(supplier)) )
            {
               MessageBox.Show("Enter All Fields To Edit", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            var id = (from s in db.Products
                      where s.Name == productName
                      select s.ProductID).FirstOrDefault();
            var searech = db.Products.Find(id);
            if (searech != null) 
            { 
                searech.Description = productDescription;
                searech.Price = productPrice;
                searech.Quantity = productQuantity;
                db.SaveChanges();
                MessageBox.Show("Product Edited successfully.");
            }
            else
            {
                MessageBox.Show("Product Not Found.");
            }
            
            txtProductName.Clear();
            txtProductDescription.Clear();
            txtProductPrice.Clear();
            txtProductQuantity.Clear();
            txtSupplier.Clear();

        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            var id = (from s in db.Products where s.Name == productName select s.ProductID).FirstOrDefault();
            var searech = db.Products.Find(id);
            if (searech != null)
            {
                db.Products.Remove(searech);
                db.SaveChanges();
                MessageBox.Show("Product Deleted successfully.");
            }
            else
            {
                MessageBox.Show("Product Not Found.");
            }
            txtProductName.Clear();
        }

        private void Delete_click(object sender, RoutedEventArgs e)
        {
            string name = txtsupplierName.Text;
            var searech = db.Suppliers.Find(name);
            if (searech != null)
            {
                db.Suppliers.Remove(searech);
                db.SaveChanges();
                MessageBox.Show("Supplier Deleted successfully.");
            }
            else
            {
                MessageBox.Show("Supplier Not Found.");
            }
            txtsupplierName.Clear();
        }

       
    }
}

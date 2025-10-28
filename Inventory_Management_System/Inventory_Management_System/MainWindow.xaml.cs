using Inventory_Management_System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inventory_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context db = new Context(); 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtname.Text;
            string password = txtPassword.Password;
            var Admin = (from s in db.Users
                        where s.Name == username&& s.Password == password && s.Role == "Admin"
                        select s).FirstOrDefault();
            var emp =( from s in db.Users
                      where s.Name == username && s.Password == password && s.Role == "Stock Clerk "
                      select s).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(username)|| string.IsNullOrEmpty(password))

            {
                txtMessage.Text = "Please enter username and password.";
                txtname.Clear();
                txtPassword.Clear();
                return;
            }
          
            else if (Admin!=null)
            {
               the_Master_Data_Page adminPage = new the_Master_Data_Page();
                adminPage.Show();
                this.Close();

            }
            else if (emp!=null)
            {
                the_Product_Stock_Page productPage = new the_Product_Stock_Page();
                productPage.Show();
                this.Close();
            }
            else
            {
    txtMessage.Text = "Invalid username or password.";
                txtname.Clear();
                txtPassword.Clear();
            }

        }
    }
}
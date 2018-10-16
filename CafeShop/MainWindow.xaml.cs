using CafeShop.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CafeShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string Username;
        public static string Password;
        public Login()
        {
            InitializeComponent();
           
            
        }

        bool Loginn(string userName, string passWord) {
            var acc = DataProvider.Ins.DB.ACCOUNTs.Where(x => x.userName == Username && x.passWord == Password).Count();
            return acc > 0;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Username = txtUsername.Text.ToString();
            Password = pwbPassword.Password.ToString();
            if (Loginn(Username, Password))
            {
                ACCOUNT accountLogin = DataProvider.Ins.DB.ACCOUNTs.Where(x => x.userName == Username).ToList().First();                
                wManager manager = new wManager(accountLogin);
                this.Hide();
                manager.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu..");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận thoát", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
                e.Cancel = true;
        }
    }
}

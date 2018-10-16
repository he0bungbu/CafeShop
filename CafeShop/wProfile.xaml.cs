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
using System.Windows.Shapes;

namespace CafeShop
{
    /// <summary>
    /// Interaction logic for wProfile.xaml
    /// </summary>
    public partial class wProfile : Window
    {
        private ACCOUNT accountLogin;
        public ACCOUNT AccountLogin
        {
            get { return accountLogin; }

            set { accountLogin = value; }
        }

        public wProfile(ACCOUNT acc)
        {
            InitializeComponent();
            this.AccountLogin = acc;
        }

        private void Window_IsStylusDirectlyOverChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = AccountLogin.userName;
            txtDisplayname.Text = AccountLogin.displayName;

            string type = (AccountLogin.type == 1) ? "admin" : "staff";
            txtType.Text = type;
            pwbPassword.Password = AccountLogin.passWord;
        }

        void Load() {
            txtUsername.Text = AccountLogin.userName;
            txtDisplayname.Text = AccountLogin.displayName;
            string type = (AccountLogin.type == 1) ? "admin" : "staff";
            txtType.Text = type;
            pwbPassword.Password = AccountLogin.passWord;        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ACCOUNT acc = DataProvider.Ins.DB.ACCOUNTs.Where(x => x.userName == AccountLogin.userName).First();
            acc.displayName = txtDisplayname.Text;
            DataProvider.Ins.DB.SaveChanges();
            ACCOUNT acc1 = DataProvider.Ins.DB.ACCOUNTs.Where(x => x.userName == AccountLogin.userName).First();
            MessageBox.Show("Bạn đã cập nhật thành công tên mới: "+acc1.displayName);
            Load();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var listacc = DataProvider.Ins.DB.ACCOUNTs.Where(x => x.userName == AccountLogin.userName).ToList();
            var acc = listacc.First();
            wChangePassword c = new wChangePassword(acc);
            c.ShowDialog();
        }
    }
}

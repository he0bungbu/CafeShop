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
    /// Interaction logic for wChangePassword.xaml
    /// </summary>
    public partial class wChangePassword : Window
    {
        private ACCOUNT accountLogin;
        public ACCOUNT AccountLogin
        {
            get { return accountLogin; }

            set { accountLogin = value; }
        }
        public wChangePassword(ACCOUNT acc)
        {
            InitializeComponent();
            this.AccountLogin = acc;
            Load();
        }
        void Load() {
            txtUsername.Text = AccountLogin.userName;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Kiem tra mat khau cu
            if (pwbOldPass.Password != AccountLogin.passWord)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu hoặc mật khẩu bạn nhập vào không chính xác");
            }
            else {
                if (pwbNewPass.Password == "")
                    MessageBox.Show("Không được bỏ trống trường này");
                else
                {
                    if (pwbReEnterNewPass.Password != pwbNewPass.Password)
                        MessageBox.Show("Mật khẩu mới nhập lại không chính xác");
                    else {
                        ACCOUNT acc = DataProvider.Ins.DB.ACCOUNTs.Where(x => x.userName == AccountLogin.userName).First();
                        acc.passWord = pwbReEnterNewPass.Password;
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Bạn đã cập nhật mật khẩu thành công");
                    }
                }
            }
        }
    }
}


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
    /// Interaction logic for wAdminTable.xaml
    /// </summary>
    public partial class wAdminTable : Window
    {
        public wAdminTable()
        {
            InitializeComponent();
            Load();
            LoadChamCong();
            LoadTongTinLuong();
        }

        void Load() {
            var listcate = DataProvider.Ins.DB.CATEGORies.ToList();
            dtgvShow.ItemsSource = listcate;            
        }

        

        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            string key = txtSearch.Text;
            if (key == "")
            {
                MessageBox.Show("Bạn phải nhập từ khóa để tìm kiếm");
            }
            else {
                int id = int.Parse(key);
                var listCateID = DataProvider.Ins.DB.CATEGORies.Where(x => x.categoryID == id).ToList();
                string name = key;
                var listCatename = DataProvider.Ins.DB.CATEGORies.Where(x => x.categoryName == name).ToList();
                if (listCateID.Count() > 0)
                {
                    dtgvShow.ItemsSource = listCateID;
                }
                else {
                    if (listCatename.Count() > 0)
                    {
                        dtgvShow.ItemsSource = listCatename;
                    }
                    else {
                        MessageBox.Show("Không tìm thấy danh mục yêu cầu");
                    }
                }                
            }            
        }

        private void btnReset_Click_1(object sender, RoutedEventArgs e)
        {
            txtCateID.Text = "";
            txtCateName.Text = "";
        }

        private void btnSua_Click_1(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtCateID.Text);
            CATEGORY cate = DataProvider.Ins.DB.CATEGORies.Where(x => x.categoryID == id).First();
            if (txtCateName.Text == "")
            {
                MessageBox.Show("Không được bỏ trống tên danh mục");
            }
            else
            {
                cate.categoryName = txtCateName.Text;
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Cập nhật tên danh mục thành công");
            }
        }

        private void btnXoa_Click_1(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtCateID.Text);
            if (txtCateID.Text == "")
            {
                MessageBox.Show("Bạn phải chọn danh mục cần xóa trước khi thực hiện hành động này");
            }
            else {
                if (txtCateName.Text == "")
                {
                    MessageBox.Show("Danh mục này không tồn tại");
                }
                else {
                    CATEGORY k = DataProvider.Ins.DB.CATEGORies.Where(x => x.categoryID == id).First();
                    if (k.categoryName != txtCateName.Text)
                    {
                        MessageBox.Show("Danh mục này không tồn tại");
                    }
                    else {
                        DataProvider.Ins.DB.CATEGORies.Remove(k);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Bạn đã xóa danh mục " + txtCateName.Text);
                        Load();
                    }
                    
                }
            }
        }

        private void btnThem_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtCateName.Text == "")
            {
                MessageBox.Show("Không được bỏ trống tên danh mục");
            }
            else {
                MessageBoxResult rs = MessageBox.Show("Bạn có muốn tạo mới một danh mục có tên là " + txtCateName.Text+" không?","Xác nhận", MessageBoxButton.OKCancel);
                if (rs == MessageBoxResult.OK) {
                    CATEGORY cate = new CATEGORY();
                    cate.categoryName = txtCateName.Text;
                    DataProvider.Ins.DB.CATEGORies.Add(cate);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Bạn đã thêm thành công 1 danh mục mới có tên là: "+ txtCateName.Text);
                    Load();
                }
            }
        }

        private void btnXem_Click_1(object sender, RoutedEventArgs e)
        {
            Load();
        }
        //Cham cong
        void LoadChamCong(){
            var list = DataProvider.Ins.DB.MUSTERs.ToList();
            dtgvChamCong.ItemsSource = list;
        }

        private void btnXem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void btnchamCong_Click_1(object sender, RoutedEventArgs e)
        {
            MUSTER must = new MUSTER();
            must.userName = cbUsername.Text;
            must.displayName = txtDisplayname.Text;
            must.muster1 = cbCaLam.Text;

            DateTime? dt = dpNgayLam.SelectedDate;
            DateTime d = DateTime.Parse(dt.ToString());
            

            //MessageBox.Show("  " + d);

            must.date = d;
            DataProvider.Ins.DB.MUSTERs.Add(must);
            DataProvider.Ins.DB.SaveChanges();
            LoadChamCong();
        }

        private void btnCapNhatChamcong_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void cbUsername_Loaded_1(object sender, RoutedEventArgs e)
        {
            var list = DataProvider.Ins.DB.ACCOUNTs.ToList();
            cbUsername.ItemsSource = list;
            cbUsername.DisplayMemberPath = "userName";
        }

        private void cbUsername_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ACCOUNT acc = cbUsername.SelectedItem as ACCOUNT;
            txtDisplayname.Text = acc.displayName;
        }

        //Luong

        void LoadTongTinLuong() {
            var list = DataProvider.Ins.DB.SALARies.ToList();
            dtgvThongTinLuong.ItemsSource = list;
        
        }
        
    }
}

using CafeShop.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for wManager.xaml
    /// </summary>
    public partial class wManager : Window
    {
        private ACCOUNT accountLogin;
        public ACCOUNT AccountLogin  {
            get { return accountLogin; }

            set { accountLogin = value; ChangeAccout(accountLogin.type); }
        }
        
        public wManager(ACCOUNT acc)
        {
            InitializeComponent();

            this.AccountLogin = acc;

            LoadTable();
        }

        void ChangeAccout(int type) {
            MenuAdmin.IsEnabled = type == 1;
            MenuThongKe.IsEnabled = type == 1;
        }

        void LoadTable() {
            List<TABLELIST> tableList = DataProvider.Ins.DB.TABLELISTs.ToList();
            foreach (TABLELIST item in tableList) {
                Button btn = new Button() {Height = 50 };
                btn.Content = item.tableName + " ---- " + item.tableStatus;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.tableStatus) { 
                    case "Trống":
                        btn.Background = Brushes.Blue;
                        break;
                    default:
                        btn.Background = Brushes.Red;
                        break;
                }
                stacklist.Children.Add(btn);
            }      
            
        }

        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as TABLELIST).tableID;
            //MessageBox.Show(tableID+"");
            ShowBill(tableID);
        }

        void ShowBill(int tableID) {
            var model = from b in DataProvider.Ins.DB.BILLs
                        join bi in DataProvider.Ins.DB.BILLINFOes
                        on b.billID equals bi.billID
                        join f in DataProvider.Ins.DB.FOODs
                        on bi.foodID equals f.foodID
                        where b.tableID == tableID && b.billStatus == 0
                        select new ShowBillByTable()
                        {
                            foodName = f.foodName,
                            soLuong = bi.count,
                            giaTien = (float) f.foodPrice
                        };
            dtgvBill.ItemsSource = model.ToList();
            float tongtien = 0;
            foreach (var item in model) {
                tongtien = tongtien + item.soLuong * item.giaTien;
            }
            CultureInfo culture = new CultureInfo("vi-VN");

            txtTongTien.Text = tongtien.ToString("c", culture);
            var table = DataProvider.Ins.DB.TABLELISTs.Where(x => x.tableID == tableID).ToList();
            var tb = table.First();
            dtgvBill.Tag = tb;
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string giamgia = cbGiamGia.SelectedValue.ToString();
            string gg = giamgia.Substring(38);

            int g = int.Parse(gg);

            string tongtien = txtTongTien.Text;
            string[] a = tongtien.Split(' ');
            string[] b = a[0].Split(',');

            float k = float.Parse(b[0]);
            CultureInfo culture = new CultureInfo("vi-VN");
            k = (k * 1000) - (k * 1000 * g / 100);

            txtTongTien.Text = k.ToString("c", culture);
            
            //MessageBox.Show(k+"");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var listacc = DataProvider.Ins.DB.ACCOUNTs.Where(x => x.userName == AccountLogin.userName).ToList();
            var acc = listacc.First();
            wProfile p = new wProfile(acc);
            p.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            wAdminTable a = new wAdminTable();
            this.Hide();
            a.ShowDialog();
            this.ShowDialog();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            wStatistics s = new wStatistics();
            this.Hide();
            s.ShowDialog();
            this.ShowDialog();
        }

        private void ComboBox_Loaded_1(object sender, RoutedEventArgs e)
        {
            var listCate = DataProvider.Ins.DB.CATEGORies.ToList();
            cbCategory.ItemsSource = listCate;
            cbCategory.DisplayMemberPath = "categoryName";
            
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            CATEGORY category = cb.SelectedItem as CATEGORY;
            id = category.categoryID;

            LoadListFoodByCategoryID(id);
        }

        void LoadListFoodByCategoryID(int id) {
            var listFood = DataProvider.Ins.DB.FOODs.Where(x => x.categoryID == id).ToList();
            cbFood.ItemsSource = listFood;
            cbFood.DisplayMemberPath = "foodName";
        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            int tableID = (dtgvBill.Tag as TABLELIST).tableID;
            //Lay du lieu tu combobox

            int foodID = (cbFood.SelectedItem as FOOD).foodID;
            int count = int.Parse(cbSoLuong.Text);
            //MessageBox.Show(count+"");


            //Kiem tra ban da thanh toan chua neu chua thi them vao bill hien tai neu roi thi tao bill moi

            if (DataProvider.Ins.DB.BILLs.Where(x => x.tableID == tableID && x.billStatus == 0).Count() > 0)
            {
                var bill = DataProvider.Ins.DB.BILLs.Where(x => x.tableID == tableID && x.billStatus == 0).ToList();
                //Lay Bill cua ban hien tai 
                var b = bill.First();
                //them billInfo moi
                BILLINFO billInfo = new BILLINFO();
                billInfo.billID = b.billID;
                billInfo.foodID = foodID;
                billInfo.count = count;
                DataProvider.Ins.DB.BILLINFOes.Add(billInfo);
                DataProvider.Ins.DB.SaveChanges();
                ShowBill(tableID);
            }
            else
            {
                //Tao bill moi
                BILL bill = new BILL();
                bill.tableID = tableID;
                bill.billStatus = 0;
                bill.username = AccountLogin.userName;
                bill.checkIn = DateTime.Now; //
                DataProvider.Ins.DB.BILLs.Add(bill);
                DataProvider.Ins.DB.SaveChanges();
                //Them billInfo moi
                BILLINFO billInfo = new BILLINFO();
                billInfo.billID = bill.billID;
                billInfo.foodID = foodID;
                billInfo.count = count;
                DataProvider.Ins.DB.BILLINFOes.Add(billInfo);
                DataProvider.Ins.DB.SaveChanges();
                //Cap nhat lai thanh ban da co nguoi
                var table = DataProvider.Ins.DB.TABLELISTs.Where(x => x.tableID == tableID).ToList(); 
                var tb = table.First();
                if (tb != null)
                    tb.tableStatus = "Có người";
                DataProvider.Ins.DB.SaveChanges();
                ShowBill(tableID);
                stacklist.Children.Clear();
                LoadTable();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TABLELIST table = dtgvBill.Tag as TABLELIST;
            int tableID = table.tableID;
            var bill = DataProvider.Ins.DB.BILLs.Where(x => x.tableID == tableID && x.billStatus == 0).ToList();
            if (bill.Count > 0)
            {
                //Lay Bill cua ban hien tai 
                var b = bill.First();
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc muốn thanh toán hóa đơn cho bàn " + table.tableName, "Xác nhận thanh toán", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (rs == MessageBoxResult.OK)
                {
                    if (b != null)
                    {
                        var tb = DataProvider.Ins.DB.TABLELISTs.Where(x => x.tableID == tableID).ToList();
                        var t = tb.First();

                        wBill w = new wBill(t);
                        w.ShowDialog();

                        b.billStatus = 1;
                        b.checkOut = DateTime.Now.Date;
                        DataProvider.Ins.DB.SaveChanges();
                        
                        t.tableStatus = "Trống";
                        DataProvider.Ins.DB.SaveChanges();
                        ShowBill(tableID);
                        stacklist.Children.Clear();
                        LoadTable();                       
                    }

                }
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.Title = "Orange Cafe - Nhân viên: "+AccountLogin.displayName;
        }

        
    }
}

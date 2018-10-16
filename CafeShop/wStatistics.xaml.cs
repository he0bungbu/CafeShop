using CafeShop.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    /// Interaction logic for wStatistics.xaml
    /// </summary>
    public partial class wStatistics : Window
    {
        public wStatistics()
        {
            InitializeComponent();
            Load();
            LoadDanhSachHoaDon();
        }

        private void btnXemtheoNgay_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Parse(dpXemtheoNgay.SelectedDate.ToString());
            var model = from b in DataProvider.Ins.DB.BILLs
                        join bi in DataProvider.Ins.DB.BILLINFOes
                        on b.billID equals bi.billID
                        join f in DataProvider.Ins.DB.FOODs
                        on bi.foodID equals f.foodID
                        where b.checkIn == dt
                        select new DoanhThu()
                        {
                            soLuong = bi.count,
                            giaTien = (float)f.foodPrice
                        };
            float tongtien = 0;
            foreach (var item in model)
            {
                tongtien = tongtien + item.soLuong * item.giaTien;
            }
            CultureInfo culture = new CultureInfo("vi-VN");

            txtTongDoanhThuTheoNgay.Text = tongtien.ToString("c", culture);
        }

        void Load() {
            var list = DataProvider.Ins.DB.BILLINFOes.ToList();
            dtgvDoanhThuRheoNgay.ItemsSource = list;
        
        }

        void LoadDanhSachHoaDon() {
            var list = DataProvider.Ins.DB.BILLs.ToList();
            dtgThongtinHoadon.ItemsSource = list;
            
        }

        private void btnXemThongtinHoadon_Click_1(object sender, RoutedEventArgs e)
        {
            rtxtShowBill.Document.Blocks.Clear();
            int id = int.Parse(txtID.Text);
            BILL Bill = DataProvider.Ins.DB.BILLs.Where(x => x.billID == id).First();
            var model = from bi in DataProvider.Ins.DB.BILLINFOes
                        join f in DataProvider.Ins.DB.FOODs
                        on bi.foodID equals f.foodID
                        where bi.billID == id
                        select new ShowBillByTable
                        {
                            foodName = f.foodName,
                            soLuong = bi.count,
                            giaTien = (float)f.foodPrice
                        };
            float tongtien = 0;
            foreach (var item in model)
            {
                tongtien = tongtien + item.soLuong * item.giaTien;
            }

            CultureInfo culture = new CultureInfo("vi-VN");

            string Tongtien = tongtien.ToString("c", culture);

            using (StreamWriter sw = new StreamWriter(@"D:\Thực tập chuyên môn\CafeShop\CafeShop\BillInfo\thongtinhoadon.txt"))
            {
                sw.WriteLine("Hóa đơn bàn :" +Bill.tableID);
                foreach (var item in model)
                {
                    string giatien = item.giaTien.ToString("c", culture);
                    sw.WriteLine(item.foodName + " --- SL: " + item.soLuong + " --- Giá: " + giatien + "/SP");
                }
                sw.WriteLine("Check in: " + Bill.checkIn);

                sw.WriteLine("Check out: " + Bill.checkOut);
                sw.WriteLine("Tổng tiền: " + Tongtien);
            }

            string line = "";
            using (StreamReader sr = new StreamReader(@"D:\Thực tập chuyên môn\CafeShop\CafeShop\BillInfo\thongtinhoadon.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Paragraph p = new Paragraph();
                    p.Inlines.Add(line);
                    rtxtShowBill.Document.Blocks.Add(p);
                }
            }
        }
    }
}

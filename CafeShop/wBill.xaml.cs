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
using System.IO;
using System.Globalization;

namespace CafeShop
{
    /// <summary>
    /// Interaction logic for wBill.xaml
    /// </summary>
    public partial class wBill : Window
    {
        private TABLELIST tableList;
        public TABLELIST Table {
            get { return tableList; }
            set { tableList = value; }
            }

        public wBill(TABLELIST table)
        {
            InitializeComponent();
            this.Table = table;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            int tableID = Table.tableID;
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
                            giaTien = (float)f.foodPrice
                        };            
            float tongtien = 0;
            foreach (var item in model)
            {
                tongtien = tongtien + item.soLuong * item.giaTien;
            }

            CultureInfo culture = new CultureInfo("vi-VN");

            string Tongtien = tongtien.ToString("c", culture);



            var bill = DataProvider.Ins.DB.BILLs.Where(x => x.tableID == tableID && x.billStatus == 0).ToList();
            //Lay Bill cua ban hien tai 
            var B = bill.First();

            using (StreamWriter sw = new StreamWriter(@"D:\CSharp\Thực tập chuyên môn\CafeShop\CafeShop\BillInfo\hoadon.txt"))
            {
                sw.WriteLine("Hóa đơn:" + Table.tableName);
                foreach (var item in model)
                {
                    string giatien = item.giaTien.ToString("c", culture);
                    sw.WriteLine(item.foodName + " --- SL: " + item.soLuong + " --- Giá: " + giatien+"/SP");
                }
                sw.WriteLine("Check in: "+ B.checkIn);
               
                sw.WriteLine("Check out: "+ DateTime.Now);
                sw.WriteLine("Tổng tiền: " + Tongtien);                
            }

            string line = "";
            using (StreamReader sr = new StreamReader(@"D:\CSharp\Thực tập chuyên môn\CafeShop\CafeShop\BillInfo\hoadon.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Paragraph p = new Paragraph();
                    p.Inlines.Add(line);
                    rtxtBill.Document.Blocks.Add(p);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

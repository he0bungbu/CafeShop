using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeShop.DAO
{
    class ADODataProvider
    {
        private static ADODataProvider instance; // Ctrl + R + E

        public static ADODataProvider Instance
        {
            get { if (instance == null) instance = new ADODataProvider(); return ADODataProvider.instance; }
            private set { ADODataProvider.instance = value; }
        }

        private ADODataProvider(){}

        private string connectionSTR = @"Data Source=.\sqlexpress;Initial Catalog=CafeShop;Integrated Security=True";
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }
    }
}

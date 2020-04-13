using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLKHOANTHU.Class
{
    class clsXuLy
    {
        public SqlConnection con = new SqlConnection();
        string chuoiKetNoi = "Data Source = .\\SQLEXPRESS;Database = QLKHOANTHU;User Instance = False;Connect Timeout =30;Integrated Security = True";
        public bool KetNoi()
        {
            try
            {
                con = new SqlConnection(chuoiKetNoi);
                con.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DongKetNoi()
        {
            con.Close();
            
        }
    }
}

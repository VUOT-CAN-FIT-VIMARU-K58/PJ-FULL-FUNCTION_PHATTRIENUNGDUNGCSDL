using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLKHOANTHU.Class
{
    class clsFunction
    {
        public DataTable GetData(string sql)
        {
            clsXuLy cn = new clsXuLy();
            cn.KetNoi();
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter dta = new SqlDataAdapter(sql,cn.con);
                dta.Fill(ds, sql);
                DataTable tbl = ds.Tables[0];
                return tbl;
            }
            catch
            {
                return null;
            }
        }

        public void Them_Sua_Xoa(string sql)
        {
            clsXuLy cn = new clsXuLy();
            cn.KetNoi();
            try
            {
                SqlCommand cmd = new SqlCommand(sql,cn.con);
                cmd.ExecuteNonQuery();
                cn.DongKetNoi();
            }
            catch { }
        }
    }
}

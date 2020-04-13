using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKHOANTHU.Class;

namespace QLKHOANTHU
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public string sql = "", MaHS = "", TenHS = "", Gioitinh = "", MaBH = "", hanhdong = "";

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHoan_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain f1 = new frmMain();
            f1.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MaHS = txtMaHS.Text;
            TenHS = txtTenHS.Text;
            MaBH = cbBacHoc.SelectedValue.ToString();
            clsFunction f1 = new clsFunction();
            if(hanhdong == "them")
            {
                if (rbNam.Checked)
                    Gioitinh = "Nam";
                else
                    Gioitinh = "Nu";

                sql = "INSERT INTO HOC_SINH (MaHS,TenHS,Gioitinh,Ngaysinh,MaBH) VALUES ('" + MaHS + "','" + TenHS + "','" + Gioitinh + "','" + dtpNgaySinh.Value + "','" + MaBH + "')";
                f1.Them_Sua_Xoa(sql);
            }
            if(hanhdong == "sua")
            {
                if (rbNam.Checked)
                    Gioitinh = "Nam";
                else
                    Gioitinh = "Nu";

                sql = "UPDATE HOC_SINH SET TenHS = '" + TenHS + "',Gioitinh ='" + Gioitinh + "',Ngaysinh = '" + dtpNgaySinh.Value + "',MaBH = '" + MaBH + "' WHERE MaHS = '" + MaHS + "'";
                f1.Them_Sua_Xoa(sql);
            }
            if(hanhdong == "xoa")
            {
                sql = "DELETE FROM HOC_SINH WHERE MaHS = '" + MaHS + "'";
                f1.Them_Sua_Xoa(sql);
            }
            TaiDuLieu();
        }

        private void dgvHocSinh_SelectionChanged(object sender, EventArgs e)
        {
            txtMaHS.Text = dgvHocSinh.CurrentRow.Cells[0].Value.ToString();
            txtTenHS.Text = dgvHocSinh.CurrentRow.Cells[1].Value.ToString();
            Gioitinh = dgvHocSinh.CurrentRow.Cells[2].Value.ToString();
            if(Gioitinh == "Nam")
            {
                rbNam.Checked = true;
            }
            else
            {
                rbNu.Checked = true;
            }
            dtpNgaySinh.Text = dgvHocSinh.CurrentRow.Cells[3].Value.ToString();
            cbBacHoc.Text = dgvHocSinh.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            hanhdong = "xoa";
        }

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            clsFunction f1 = new clsFunction();
            sql = "SELECT * FROM BH_HS WHERE Gioitinh like '"+txtTimKiem.Text+"'";
            dgvHocSinh.DataSource = f1.GetData(sql);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            hanhdong = "sua";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            hanhdong = "them";
            txtMaHS.Text = "";
            txtTenHS.Text = "";
        }

        public void TaiDuLieu()
        {
            clsFunction f1 = new clsFunction();
            sql = "SELECT * FROM BH_HS";
            dgvHocSinh.DataSource = f1.GetData(sql);
        }

        public void read_BacHoc()
        {
            clsFunction f1 = new clsFunction();
            sql = "SELECT MaBH,TenBH FROM BAC_HOC";
            cbBacHoc.DisplayMember = "TenBH";
            cbBacHoc.ValueMember = "MaBH";
            cbBacHoc.DataSource = f1.GetData(sql);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            clsXuLy cn = new clsXuLy();
            if (cn.KetNoi())
            {
                MessageBox.Show("Kết nối thành công !");
            }
            else
                MessageBox.Show("Kết nối không thành công !");
            read_BacHoc();
            TaiDuLieu();
        }
    }
}

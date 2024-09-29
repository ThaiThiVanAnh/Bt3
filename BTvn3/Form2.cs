using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BTvn3.Form1;

namespace BTvn3
{
    public partial class FrmNhanVien : Form
    {
        public NhanVien NhanVien { get; set; }

        public FrmNhanVien()
        {
            InitializeComponent();
        }

        

        

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            if (NhanVien != null)
            {
                textBox1.Text = NhanVien.MSNV;
                textBox2.Text = NhanVien.TenNV;
                textBox3.Text = NhanVien.LuongCB.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhanVien = new NhanVien
            {
                MSNV = textBox1.Text,
                TenNV = textBox2.Text,
                LuongCB = decimal.Parse(textBox3.Text)
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTvn3
{
    public partial class Form1 : Form
    {
        public class NhanVien
        {
            public string MSNV { get; set; }
            public string TenNV { get; set; }
            public decimal LuongCB { get; set; }
        }


        private List<NhanVien> nhanVienList = new List<NhanVien>();


        public Form1()
        {
            InitializeComponent();
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            FrmNhanVien formNhanVien = new FrmNhanVien();
            if (formNhanVien.ShowDialog() == DialogResult.OK)
            {
                nhanVienList.Add(formNhanVien.NhanVien);
                LoadDataGridView();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count == 0) return;

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                FrmNhanVien formNhanVien = new FrmNhanVien();
                formNhanVien.NhanVien = new NhanVien
                {
                    MSNV = selectedRow.Cells[0].Value.ToString(),
                    TenNV = selectedRow.Cells[1].Value.ToString(),
                    LuongCB = Convert.ToDecimal(selectedRow.Cells[2].Value)
                };

                if (formNhanVien.ShowDialog() == DialogResult.OK)
                {
                    var updatedNhanVien = formNhanVien.NhanVien;
                    selectedRow.Cells[0].Value = updatedNhanVien.MSNV;
                    selectedRow.Cells[1].Value = updatedNhanVien.TenNV;
                    selectedRow.Cells[2].Value = updatedNhanVien.LuongCB;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.");
            }
        }
        private void LoadDataGridView()
        {
           
            dataGridView1.Rows.Clear();
            foreach (var nv in nhanVienList)
            {
                dataGridView1.Rows.Add(nv.MSNV, nv.TenNV, nv.LuongCB);
            }

        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}

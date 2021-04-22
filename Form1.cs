using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgvProducts.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbName.Text,
                UnitPrice = Convert.ToDecimal(tbUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbStockAmount.Text)
            });
            LoadProducts();
            MessageBox.Show("Product added.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value),
                Name = tbUName.Text,
                UnitPrice = Convert.ToDecimal(tbUUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbUStockAmount.Text)
            };
            _productDal.Update(product);
            LoadProducts();
            MessageBox.Show("Product updated.");
            
        }

        
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbUName.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            tbUUnitPrice.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            tbUStockAmount.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            LoadProducts();
            MessageBox.Show("Product deleted.");
        }
    }
}

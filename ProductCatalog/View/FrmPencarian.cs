using ProductCatalog.Controller;
using ProductCatalog.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductCatalog.View
{
    public partial class FrmPencarian : Form
    {
        private ProductController productController = new ProductController();
        public FrmPencarian()
        {
            InitializeComponent();
            
            InisialisasiListView();
            cmbFilter.SelectedIndex = 0;
        }

        private void InisialisasiListView()
        {
            lvwProduct.View = System.Windows.Forms.View.Details;
            lvwProduct.FullRowSelect = true;
            lvwProduct.GridLines = true;

            lvwProduct.Columns.Add("No.", 40, HorizontalAlignment.Center);
            lvwProduct.Columns.Add("Product Id", 120, HorizontalAlignment.Left);
            lvwProduct.Columns.Add("Product Name", 750, HorizontalAlignment.Left);
            lvwProduct.Columns.Add("Stock", 40, HorizontalAlignment.Center);
            lvwProduct.Columns.Add("Price", 70, HorizontalAlignment.Right);
            lvwProduct.Columns.Add("Category", 300, HorizontalAlignment.Left);
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            lvwProduct.Items.Clear();
            List<Product> listOfProduct = new List<Product>();

            switch (cmbFilter.SelectedIndex)
            {
                case 0:
                    listOfProduct = productController.ReadAll();
                    break;
                case 1:
                    listOfProduct.Add(productController.ReadByProductId(txtKeyword.Text));
                    break;
                case 2:
                    listOfProduct = productController.ReadByProductName(txtKeyword.Text);
                    break;
                case 3:
                    listOfProduct = productController.ReadByCategory(txtKeyword.Text);
                    break;
            }

            foreach (var obj in listOfProduct)
            {
                var noUrut = lvwProduct.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(obj.product_id);
                item.SubItems.Add(obj.product_name);
                item.SubItems.Add(obj.stock.ToString());
                item.SubItems.Add(obj.price.ToString());
                item.SubItems.Add(obj.category);

                lvwProduct.Items.Add(item);
            }
        }
    }
}

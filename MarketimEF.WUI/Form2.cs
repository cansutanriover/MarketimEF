
using MarketimEF.DTO;
using MarketimEF.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketimEF.WUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            using (ProductService service=new ProductService())
            {
                ProductDTO productDTO = new ProductDTO
                {
                    ProductName = txtProductName.Text,
                    CategoryId = Convert.ToByte(txtCategoryId.Text),
                    SupplierId = Convert.ToByte(txtSupplierId.Text),
                    UnitId = Convert.ToByte(txtUnitId.Text),
                    UnitPrice = Convert.ToDecimal(txtUnitPrice.Text),
                    UnitsInStock = Convert.ToInt32(txtUnitInStock.Text),
                    RecordStatusId = 1,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now
                };
                int effected = service.Save(productDTO);
            }
        }
    }
}

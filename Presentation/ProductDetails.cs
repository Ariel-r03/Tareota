using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Poco;

namespace Presentation
{
    public partial class ProductDetails : UserControl
    {

        public Product product { get; set; }
        public ProductDetails()
        {
            InitializeComponent();
            product = new Product();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            pcb.Image = Image.FromFile(product.ImageURL);


            txtName.Text = product.Name;
            txtBrand.Text = product.Brand;
            txtModel.Text = product.Model;
            txtPrice.Text = Convert.ToString(product.Price);
            txtDesc.Text = product.Description;
        }
    }
}

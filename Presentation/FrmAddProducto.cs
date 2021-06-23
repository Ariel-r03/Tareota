using Core;
using Core.Poco;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    
    public partial class FrmAddProducto : Form
    {
        String dir;
        private ProductRepository productRepository;
        //private IClientRepository clientRepository;
        public FrmAddProducto()
        {
            //this.productRepository = productRepository;
            InitializeComponent();
            productRepository = new ProductRepository();
        }

        private void FrmAddProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String description = txtDescription.Text;
            String marca = TxtMarca.Text;
            String modelo = txtModelo.Text;
            String direction = dir;
            decimal price = Decimal.Parse(txtPrice.Text);
            int cantidad = (int)nCantida.Value;

            Create(name, description, marca, modelo, direction, cantidad, price);
        }
        public void Create(String name, String descrip, String marca, String modelo, String direction, int cant, decimal price)
        {
            Product p = new Product()
            {
                Name = name,
                Description = descrip,
                Brand = marca,
                Model = modelo,
                ImageURL = direction,
                Price = price,
                Stock = cant
            };
            productRepository.Create(p);
        }
        private void btnExplorar_Click(object sender, EventArgs e)
        {
            using (var fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    dir = fd.SelectedPath;
                }
            }
        }
    }
}

using Core;
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
    public partial class Principal : Form
    {
        private ProductRepository productRepository;
        private IClientRepository clientRepository;

        public Principal(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
            InitializeComponent();
            changePanel();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void changePanel()
        {
            pnlSubMenuOptions.Visible = false;
            pnlSubMenuProducto.Visible = false;
        }
        // para ocultarlos
        private void hideSubMenu()
        {
            if (pnlSubMenuOptions.Visible == true)
                pnlSubMenuOptions.Visible = false;

            if (pnlSubMenuProducto.Visible == true)
                pnlSubMenuProducto.Visible = false;
        }

        private void showingSubMenues(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        //Usuario
        private void btnUserOptions_Click(object sender, EventArgs e)
        {
            showingSubMenues(pnlSubMenuOptions);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            openChildForm(new frmCreate(clientRepository));			
            // que se oculte
            hideSubMenu();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {


            // que se oculte
            hideSubMenu();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


            // que se oculte
            hideSubMenu();
        }
        //Producto
        private void btnProductos_Click(object sender, EventArgs e)
        {
            showingSubMenues(pnlSubMenuProducto);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            // que se oculte
            hideSubMenu();
        }

        private void btnShowProduct_Click(object sender, EventArgs e)
        {


            // que se oculte
            hideSubMenu();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {


            // que se oculte
            hideSubMenu();
        }
    }
}

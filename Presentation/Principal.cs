using Core;
using Infraestructure.Data;
using Presentation.showUser;
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
        private IClientRepository clientRepository = new ClientRepository();

        public Principal()
        {
            //this.clientRepository = clientRepository;
            InitializeComponent();
            changePanel();
            picProduct.Visible = false;
            picUser.Visible = false;
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
            picUser.Visible = true;
            showingSubMenues(pnlSubMenuOptions);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            openChildForm(new frmCreate1());			
            // que se oculte
            hideSubMenu();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            openChildForm(new MostrarUsuario());

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
            picProduct.Visible = true;
            showingSubMenues(pnlSubMenuProducto);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmAddProducto());
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

        private Form activeF = null;
        private void openChildForm(Form childForm)
        {
            if (activeF != null)
                activeF.Close();
            activeF = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;//quitar borde de formulario
            childForm.Dock = DockStyle.Fill;
            // agregar form a panel contenedor
            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;

            //mostrar
            childForm.Show();

        }
    }
}

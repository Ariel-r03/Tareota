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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmCreate : Form
    {
        private ProductRepository productRepository;
        private IClientRepository clientRepository;
        //IClientRepository clientRepository = new ClientRepository();
        public frmCreate(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
            InitializeComponent();
            lblBadInputs.Visible = false;
            lblCorrectInput.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAcept_Click(object sender, EventArgs e)
        {

            String name = txtName.Text;
            String lastName = txtLastName.Text;
            String email = isEmail(txtEmail.Text) ? txtEmail.Text : "no";
            String numberPhone = isNumberPhone(txtNumberPhone.Text) ? txtNumberPhone.Text : "no";
            if (!ValidateTextBox(name, lastName, email, numberPhone))
            {
                lblBadInputs.Visible = true;
            }
            else
            {
                Create(name, lastName, email, numberPhone);
                lblBadInputs.Visible = false; 
                lblCorrectInput.Visible = true;
            }

            

        }
        private void Create(String name, String lastName, String email, String number)
        {
            Client client = new Client()
            {
                Name = name,
                Lastname = lastName,
                Email = email,
                Phone = number
            };
            clientRepository.Create(client);
            
        }
        private bool ValidateTextBox(String name, String lastName, String email, String number)
        {
            if (string.IsNullOrEmpty(txtEmail.Text)|| string.IsNullOrEmpty(txtLastName.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtNumberPhone.Text))
            {
                return false;
            }
            if (email.Equals("no") || number.Equals("no"))
            {
                return false;
            }
            return true;

        }
        private bool isEmail(String e)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(e, expresion))
            {
                if (Regex.Replace(e, expresion, String.Empty).Length == 0)
                    return true;             
                else               
                    return false;
            }
            else
            {
                return false;
            }
        }
        private bool isNumberPhone(String n)
        {
            Regex regex = new Regex("\\A[0-9]{7,10}\\z");
            Match match = regex.Match(n);

            if (match.Success)
                return true;
            else
                return false;
        }

        private void lblBadInputs_Click(object sender, EventArgs e)
        {

        }
    }
}

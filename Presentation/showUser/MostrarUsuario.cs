using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infraestructure.Data;
using Core.Poco;

namespace Presentation.showUser
{
    public partial class MostrarUsuario : Form
    {
        private DataTable tabluca;
        private ClientRepository clientRepository;

        public MostrarUsuario()
        {
            InitializeComponent();
            clientRepository = new ClientRepository();
        }

        private void MostrarUsuario_Load(object sender, EventArgs e)
        {
            dgvTabla.DataSource = null;
            dgvTabla.Rows.Clear();
            tabluca = new DataTable();
            tabluca.Columns.Add("Nombre");
            tabluca.Columns.Add("Apellido");
            tabluca.Columns.Add("E-Mail");
            tabluca.Columns.Add("Numero");
            if(clientRepository.GetAll() == null)
            {
                return;
            }
            foreach (Client c in clientRepository.GetAll())
            {
                if ( c == null)
                {
                    continue;
                }
                DataRow fila = tabluca.NewRow();

                fila["Nombre"] = c.Name;
                fila["Apellido"] = c.Lastname;
                fila["E-Mail"] = c.Email;
                fila["Numero"] = c.Phone;
                tabluca.Rows.Add(fila);

            }
            dgvTabla.DataSource = tabluca;

        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (dgvTabla.DataSource == null)
            {
                return;
            }

            if (dgvTabla.CurrentCell == null)
            {
                return;
            }

            int index = dgvTabla.CurrentCell.RowIndex;

            if (index < 0)
            {
                return;
            }

            int id = int.Parse(dgvTabla.Rows[index].Cells[0].Value.ToString());
            clientRepository.Delete(clientRepository.Get<Client>(id));
        }
    }
}

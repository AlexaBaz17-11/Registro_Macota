using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Registro_Macota
{
    public partial class Form1Registro_Macota : Form
    {
        private List<Dueno> listaDuenos;
        private List<Mascota> listaMascotas;

        public Form1Registro_Macota()
        {
            InitializeComponent();
            listaDuenos = new List<Dueno>();
            listaMascotas = new List<Mascota>();
        }

        private void Form1Registro_Macota_Load(object sender, EventArgs e)
        {
            // Aquí puedes inicializar el ComboBox con los dueños registrados
            foreach (Dueno dueno in listaDuenos)
            {
                comboBoxDueñoMascota.Items.Add(dueno);
            }
        }

        private void buttonRegistrarDueño_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textBoxNombreDueño.Text;
                string direccion = textBoxDirecciónDueño.Text;
                string telefono = textBoxTeléfonoDueño.Text;

                Dueno nuevoDueno = new Dueno(nombre, direccion, telefono);
                listaDuenos.Add(nuevoDueno);

                // Actualizar el ComboBox con el nuevo dueño registrado
                comboBoxDueñoMascota.Items.Add(nuevoDueno);

                // Limpiar los campos de entrada
                textBoxNombreDueño.Clear();
                textBoxDirecciónDueño.Clear();
                textBoxTeléfonoDueño.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el dueño: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRegistrarMascota_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreMascota = textBoxNombreMascota.Text;
                int edad = int.Parse(textBoxEdadMascota.Text);
                string raza = textBoxRazaMascota.Text;
                Dueno dueno = comboBoxDueñoMascota.SelectedItem as Dueno;

                Mascota nuevaMascota = new Mascota(nombreMascota, edad, raza, dueno);
                listaMascotas.Add(nuevaMascota);

                // Limpiar los campos de entrada
                textBoxNombreMascota.Clear();
                textBoxEdadMascota.Clear();
                textBoxRazaMascota.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la mascota: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBuscarMascota_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreMascota = textBoxBuscarMascota.Text;

                // Buscar la mascota en la lista de mascotas existente
                Mascota mascotaEncontrada = listaMascotas.FirstOrDefault(m => m.Nombre == nombreMascota);

                if (mascotaEncontrada != null)
                {
                    // Mostrar la mascota encontrada en el ListBox
                    listBoxRegistroMascota.Items.Clear();
                    listBoxRegistroMascota.Items.Add(mascotaEncontrada.Dueno.Nombre); // Mostrar solo el nombre del dueño
                    MessageBox.Show("La mascota se encuentra registrada.", "Búsqueda de Mascota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("No se encontró ninguna mascota con ese nombre.", "Búsqueda de Mascota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Limpiar el campo de entrada
                textBoxBuscarMascota.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la mascota: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class Dueno
        {
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public List<Mascota> Mascotas { get; set; }

            public Dueno(string nombre, string direccion, string telefono)
            {
                Nombre = nombre;
                Direccion = direccion;
                Telefono = telefono;
                Mascotas = new List<Mascota>();
            }

            public override string ToString()
            {
                return Nombre;
            }
        }

        public class Mascota
        {
            public string Nombre { get; set; }
            public int Edad { get; set; }
            public string Raza { get; set; }
            public Dueno Dueno { get; set; }



            public Mascota(string nombre, int edad, string raza, Dueno dueno)
            {
                Nombre = nombre;
                Edad = edad;
                Raza = raza;
                Dueno = dueno;

                // Agregar la mascota a la lista de mascotas del dueño
                dueno.Mascotas.Add(this);
            }

            public override string ToString()
            {
                return Nombre;
            }
        }
    }
}
        
    
    
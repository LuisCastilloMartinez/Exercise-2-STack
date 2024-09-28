using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static Stack<ClaseAuto> Pila = new Stack<ClaseAuto>();
        private void btnExit_Click(object sender, EventArgs e) { Application.Exit(); }

        public Form1()
        {
            InitializeComponent();
            MostrarDataGridView();
        }

        private void CrearDataGrid()
        {
            dgvDatos.Columns.Add("Placas", "Placas");
            dgvDatos.Columns.Add("Propietario", "Propietario");
            dgvDatos.Columns.Add("Hora de entrada", "Hora de entrada");
        }
        private void MostrarDataGridView()
        {
            ClaseAuto auto;
            dgvDatos.Rows.Clear();
            dgvDatos.Columns.Clear();
            CrearDataGrid();
            txtTop.Text = Pila.Count.ToString();

            try
            {
                foreach (ClaseAuto dato in Pila)
                {
                    Console.WriteLine(dato);
                    dgvDatos.Rows.Add(dato.Placas, dato.Propietario, dato.HoraEntrada);
                }
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show("\n\nPila Vacia..." + e.Message);
            }
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            ClaseAuto Auto = new ClaseAuto();
            Auto.Placas = txtPlacas.Text;
            Auto.Propietario = txtPropietario.Text;
            Auto.HoraEntrada = DateTime.Now;
            try
            {
                Pila.Push(Auto);
                MostrarDataGridView();
                MessageBox.Show("Placas: " + Auto.Placas +
                    "\n\nPropietario: "+ Auto.Propietario +
                    "\n\nHora de Entrada: " + Auto.HoraEntrada, "Entrada de Auto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("¡Estacionamiento lleno!");
            }
            txtPlacas.Clear();
            txtPropietario.Clear();
            txtTop.Clear();
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            try
            {
                ClaseAuto Auto = Pila.Pop();
                DateTime HoraSalida = DateTime.Now;

                int min = Math.Abs(HoraSalida.Minute - Auto.HoraEntrada.Minute);
                if (min == 0) min = 1;

                double importe = min * 0.25;

                MostrarDataGridView();
                MessageBox.Show("Placas: " + Auto.Placas + "\n\nPropietario: " + Auto.Propietario);
            }
            catch
            {
                MessageBox.Show("¡Estacionamiento Vacio!");
            }
        }
    }
}

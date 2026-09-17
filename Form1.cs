using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Form1 : Form
    {
        private Label lblInfo;
        private TextBox txtEntrada;
        private Button btnProbar;

        private int numeroSecreto;
        private int intentosMax = 5;
        private int intentos;

        public Form1()
        {
            InitializeComponent();
            CrearControles();
            IniciarJuego();
        }

        private void CrearControles()
        {
            this.Text = "Juego sencillo - Adivina el número";
            this.ClientSize = new Size(400, 200);

            lblInfo = new Label()
            {
                Text = "Adivina el número (1-10). Intentos: 0/5",
                AutoSize = true,
                Location = new Point(20, 20)
            };
            this.Controls.Add(lblInfo);

            txtEntrada = new TextBox()
            {
                Location = new Point(20, 60),
                Width = 100
            };
            this.Controls.Add(txtEntrada);

            btnProbar = new Button()
            {
                Text = "Probar",
                Location = new Point(140, 60),
                Width = 80
            };
            btnProbar.Click += BtnProbar_Click;
            this.Controls.Add(btnProbar);
        }

        private void IniciarJuego()
        {
            Random rnd = new Random();
            numeroSecreto = rnd.Next(1, 11); // número entre 1 y 10
            intentos = 0;
            lblInfo.Text = $"Adivina el número (1-10). Intentos: {intentos}/{intentosMax}";
            txtEntrada.Text = "";
        }

        private void BtnProbar_Click(object sender, EventArgs e)
        {
            int numeroJugador;

            // IF para validar entrada
            if (int.TryParse(txtEntrada.Text, out numeroJugador))
            {
                intentos++;

                // IF para comprobar si acertó
                if (numeroJugador == numeroSecreto)
                {
                    MessageBox.Show("¡Ganaste! Encontraste el número.", "Victoria");
                    IniciarJuego();
                }
                else
                {
                    MessageBox.Show("Incorrecto. Sigue intentando.", "Fallaste");
                }

                lblInfo.Text = $"Intentos: {intentos}/{intentosMax}";

                // WHILE para controlar intentos
                while (intentos >= intentosMax)
                {
                    MessageBox.Show($"Perdiste. El número era {numeroSecreto}.", "Fin del juego");
                    IniciarJuego();
                    break; // salimos del WHILE
                }
            }
            else
            {
                MessageBox.Show("Ingresa un número válido.", "Error");
            }
        }
    }
}
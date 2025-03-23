using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace Laberinto
{
    public partial class Form1 : Form
    {
        //Variables Globales
        private char[,] mapa = new char[10, 10];
        Jugador jugador; 
        private int turnos; 
        private int intentos; 
        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            txt_mapa.Enabled = false;
            txt_mapa.Font = new Font("Consolas", 30);
            txt_mapa.TextAlign = HorizontalAlignment.Center;
            txt_turnos.Enabled = false;
            txt_turnos.TextAlign = HorizontalAlignment.Center;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Laberinto";

            string ruta = archivo();
            if (ruta == null)
            {
                MessageBox.Show("Hubo un problema al cargar el archivo", "Error");
                return;
            }

            lectura(ruta);
            this.Visible = true;
        }

        private string archivo()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt",
                Title = "Selecciona el laberinto",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return null;
        }

        private void lectura(string ruta)
        {
            try
            {
                using (StreamReader reader = new StreamReader(ruta, Encoding.Default))
                {
                    int row = 0;

                    while (!reader.EndOfStream && row < 10)
                    {
                        string linea = reader.ReadLine();

                        if (row == 0)
                        {
                            if (!int.TryParse(linea, out turnos))
                            {
                                throw new Exception("El archivo no tiene un formato válido.");
                            }
                            txt_turnos.Text = turnos.ToString();
                        }
                        else
                        {
                            for (int col = 0; col < linea.Length && col < 10; col++)
                            {
                                mapa[row - 1, col] = linea[col];

                                if (linea[col] == 'i')
                                {
                                    jugador = new Jugador(row - 1, col);
                                }
                            }
                        }

                        row++;
                    }
                }

                if (jugador == null)
                {
                    throw new Exception("No se encontró la posición del jugador en el mapa.");
                }

                actualizarMapa();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en la lectura");
            }
        }

        private void actualizarMapa()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sb.Append(mapa[i, j]);
                }
                sb.AppendLine();
            }

            txt_mapa.Text = sb.ToString();
            txt_mapa.Refresh();
        }

        private void turno(string seleccion)
        {
            turnos--;
            intentos++;

            int deltaX = 0;
            int deltaY = 0;

            if (seleccion == "u") deltaX = -1;
            else if (seleccion == "d") deltaX = 1;
            else if (seleccion == "l") deltaY = -1;
            else if (seleccion == "r") deltaY = 1;

            int nextX = jugador.X + deltaX;
            int nextY = jugador.Y + deltaY;

            if (nextX >= 0 && nextX < 10 && nextY >= 0 && nextY < 10 && mapa[nextX, nextY] == 'x')
            {
                return;
            }

            int originalX = jugador.X;
            int originalY = jugador.Y;

            mapa[jugador.X, jugador.Y] = ' ';

            bool encontroPared = false;
            while (!encontroPared)
            {
                jugador.X += deltaX;
                jugador.Y += deltaY;

                if (jugador.X < 0) jugador.X = 9;
                if (jugador.X > 9) jugador.X = 0;
                if (jugador.Y < 0) jugador.Y = 9;
                if (jugador.Y > 9) jugador.Y = 0;

                if (mapa[jugador.X, jugador.Y] == 'x')
                {
                    jugador.X -= deltaX;
                    jugador.Y -= deltaY;
                    encontroPared = true;
                }
                else if (mapa[jugador.X, jugador.Y] == 'f')
                {
                    MessageBox.Show("¡Felicidades! Has encontrado la salida en " + intentos.ToString() + " intentos te quedaron " + turnos.ToString() + " turnos.");
                    this.Close();
                }
            }

            mapa[jugador.X, jugador.Y] = 'i';

            if (turnos <= 0)
            {
                MessageBox.Show("¡Has perdido! Alcanzaste el número máximo de turnos!, tus intentos fueron " + intentos.ToString());
                this.Close();
            }

            actualizarMapa();
            txt_turnos.Text = turnos.ToString();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txt_mapa_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            string seleccion = "";
            if (e.KeyCode == Keys.Up) seleccion = "u";
            else if (e.KeyCode == Keys.Down) seleccion = "d";
            else if (e.KeyCode == Keys.Left) seleccion = "l";
            else if (e.KeyCode == Keys.Right) seleccion = "r";

            turno(seleccion);
        }

    }
}

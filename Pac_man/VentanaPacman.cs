using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pac_man
{

    public partial class VentanaPrincipal : Form
    {
        //Declaración de Variables Globales

        Direcciones direccionPacman = new Direcciones();
        Direcciones direccionFantasmas = new Direcciones();
        int Velocidad_Pacman = 3;
        int InkySpeed = 3;
        int PinkySpeed = 4;
        int ClydeSpeed = 2;
        int BlinkySpeed = 5;
        int score = 0;
        int Vidas = 3; 
        bool ModoPastilla = false; 
        List<PictureBox> muros = new List<PictureBox>();

        Random random = new Random();
        bool isGameOver;
        Image imagenOriginalBlinky;
        Image imagenOriginalPinky;
        Image imagenOriginalInky;
        Image imagenOriginalClyde;
        Point posicionInicialBlinky = new Point(60, 580);
        Point posicionInicialPinky = new Point(682, 34);
        Point posicionInicialInky = new Point(700, 41);
        Point posicionInicialClyde = new Point(320, 34);


        //Clase de Colisión Pacman Con paredes
        public class Colision 
        {
            public static bool Colision_Pacman_con_Muros(PictureBox PacMan, List<PictureBox> muros)
            {
                foreach (PictureBox Pared in muros)
                {
                    if (PacMan.Bounds.IntersectsWith(Pared.Bounds))
                    {
                        return true;
                    }
                }
                return false;
            }

            public static bool Colision_Fantasmas_Con_Muros(List<PictureBox> fantasmas, List<PictureBox> muros)
            {
                foreach (PictureBox fantasma in fantasmas)
                {
                    foreach (PictureBox pared in muros)
                    {
                        if (fantasma.Bounds.IntersectsWith(pared.Bounds))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public VentanaPrincipal()
        {

            InitializeComponent();
            this.KeyDown += VentanaPrincipal_KeyDown;

            TimerPkman.Tick += timer1_Tick;
            TimerPkman.Interval = 30;
            TimerPkman.Start();
            imagenOriginalBlinky = Blinky.Image;
            imagenOriginalPinky = Pinky.Image;
            imagenOriginalInky = Inky.Image;
            imagenOriginalClyde = Clyde.Image;
            //Lista de Muros

            muros.Add(Pared2);
            muros.Add(Pared37);
            muros.Add(Pared4);
            muros.Add(Pared6);
            muros.Add(Pared8);
            muros.Add(Pared10);
            muros.Add(Pared12);
            muros.Add(Pared13);
            muros.Add(Pared14);
            muros.Add(Pared15);
            muros.Add(Pared16);
            muros.Add(Pared17);
            muros.Add(Pared18);
            muros.Add(Pared19);
            muros.Add(Pared20);
            muros.Add(Pared25);
            muros.Add(Pared26);
            muros.Add(Pared27);
            muros.Add(Pared31);
            muros.Add(Pared32);
            muros.Add(Pared33);
            muros.Add(Pared34);
            muros.Add(Pared35);
            muros.Add(Pared36);
            //Fin Lista de muros

            //Lista de Fantasmas
         
            //Fin Lista de Fantasmas
        }          

        private void PacMan_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Clase de Direcciones de Pacman //
        public class Direcciones
        {
            public bool Arriba { get; set; }
            public bool Abajo { get; set; }
            public bool Izquierda { get; set; }
            public bool Derecha { get; set; }
        }

        public class VerificadorTeclasPresionadas
        {
            private Direcciones direccion;
            public VerificadorTeclasPresionadas(Direcciones D)
            {
                direccion = D;
            }
            public void Verificador(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                {

                    direccion.Arriba = true;
                    direccion.Abajo = false;
                    direccion.Izquierda = false;
                    direccion.Derecha = false;
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    direccion.Abajo = true;
                    direccion.Arriba = false;
                    direccion.Izquierda = false;
                    direccion.Derecha = false;
                }
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    direccion.Arriba = false;
                    direccion.Abajo = false;
                    direccion.Derecha = true;
                    direccion.Izquierda = false;
                }
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    direccion.Arriba = false;
                    direccion.Abajo = false;
                    direccion.Izquierda = true;
                    direccion.Derecha = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            ScoreTXT.Text = "Score:" + score;
            VidasTXT.Text = "Vidas:" + Vidas; 
           
            if (Vidas == 0) 
            {
                isGameOver = true; 
            }

            //--Inicio de Pacman--//
                int nuevaPosX = PacMan.Location.X;
                int nuevaPosY = PacMan.Location.Y;
    
                bool colisionDetectada = false;

                foreach (PictureBox Pared in muros)
                {
                    if (PacMan.Bounds.IntersectsWith(Pared.Bounds))
                    {
                        colisionDetectada = true;

                        if (direccionPacman.Arriba)
                        {
                            nuevaPosY = Pared.Bottom;
                            direccionPacman.Arriba = false;
                            direccionPacman.Abajo = false;
                            direccionPacman.Izquierda = false;
                            direccionPacman.Derecha = false;
                        }
                        else if (direccionPacman.Abajo)
                        {
                            nuevaPosY = Pared.Top - PacMan.Height;
                            direccionPacman.Arriba = false;
                            direccionPacman.Abajo = false;
                            direccionPacman.Izquierda = false;
                            direccionPacman.Derecha = false;
                        }
                        else if (direccionPacman.Derecha)
                        {
                            nuevaPosX = Pared.Left - PacMan.Width;
                            direccionPacman.Arriba = false;
                            direccionPacman.Abajo = false;
                            direccionPacman.Izquierda = false;
                            direccionPacman.Derecha = false;
                        }
                        else if (direccionPacman.Izquierda)
                        {
                            nuevaPosX = Pared.Right;
                            direccionPacman.Arriba = false;
                            direccionPacman.Abajo = false;
                            direccionPacman.Izquierda = false;
                            direccionPacman.Derecha = false;
                        }
                        break; 
                    }
                }
                if (!colisionDetectada)
                {
                    if (direccionPacman.Arriba)
                    {
                        PacMan.Image = Properties.Resources.PacManArriba;
                        nuevaPosY -= Velocidad_Pacman;
                    }

                    if (direccionPacman.Abajo)
                    {
                        PacMan.Image = Properties.Resources.PacManAbajo;
                        nuevaPosY += Velocidad_Pacman;
                    }

                    if (direccionPacman.Derecha)
                    {
                        PacMan.Image = Properties.Resources.PacManDerecha;
                        nuevaPosX += Velocidad_Pacman;
                    }

                    if (direccionPacman.Izquierda)
                    {
                        PacMan.Image = Properties.Resources.PacManIzquierda;
                        nuevaPosX -= Velocidad_Pacman;
                    }
                }
            // Controlador de Teleport de Pacman en Derecha e Izquierda.
            if (nuevaPosX < -PacMan.Width)
            {
                nuevaPosX = this.ClientSize.Width;
            }

            if (nuevaPosX > this.ClientSize.Width)
            {
                nuevaPosX = -PacMan.Width;
            }

            // Controlador de Teleport de Pacman Arriba y Abajo.
            if (nuevaPosY + PacMan.Height < 0)
            {
                nuevaPosY = this.ClientSize.Height;
            }

            if (nuevaPosY > this.ClientSize.Height)
            {
                nuevaPosY = -PacMan.Height;
            }
    
            PacMan.Location = new Point(nuevaPosX, nuevaPosY);

            //--Fin de Pacman--//

            //--Coso de las monedas--//

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if((string)x.Tag == "Moneda" && x.Visible == true) 
                    {
                        if (PacMan.Bounds.IntersectsWith(x.Bounds)) 
                        {
                            score += 20;
                            x.Visible = false;
                            CheckFinJuego();
                        }
                    }
                    if ((string)x.Tag == "Frutas" && x.Visible == true)
                    {
                        if (PacMan.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 200;
                            x.Visible = false;
                            
                        }
                    }
                    if ((string)x.Tag == "SuperPastilla" && x.Visible == true)
                    {
                        if (PacMan.Bounds.IntersectsWith(x.Bounds))
                        {

                            score += 200;
                            x.Visible = false;
                            SuperPastillaComida(); 
                            TMRSuperPastilla.Start();
                            
                        }
                    }

                    if ((string)x.Tag == "Fantasmas" && x.Visible == true)
                    {
                        if (PacMan.Bounds.IntersectsWith(x.Bounds))
                        {
                            if (ModoPastilla == true)
                            {
                                
                                score += 200;
                                if (x.Name == "Blinky")
                                {
                                    x.Location = posicionInicialBlinky;
                                }
                                else if (x.Name == "Pinky")
                                {
                                    x.Location = posicionInicialPinky;
                                }
                                else if (x.Name == "Inky")
                                {
                                    x.Location = posicionInicialInky;
                                }
                                else if (x.Name == "Clyde")
                                {
                                    x.Location = posicionInicialClyde;
                                }
                            }
                            else
                            {
                                score -= 500;
                                TimerPkman.Stop();
                                RestarVidas();
                            }
                        }
                    } 
                }
            }

            Inky.Top += InkySpeed;

            if (Inky.Bounds.IntersectsWith(Pared4.Bounds) || Inky.Bounds.IntersectsWith(Pared35.Bounds))
            {
                InkySpeed = -InkySpeed;
            }

            Blinky.Left -= BlinkySpeed;

            if (Blinky.Bounds.IntersectsWith(Pared36.Bounds) || Blinky.Bounds.IntersectsWith(Pared34.Bounds))
            {
                BlinkySpeed = -BlinkySpeed;
            }

            Pinky.Left += PinkySpeed;

            if (Pinky.Bounds.IntersectsWith(Pared16.Bounds) || Pinky.Bounds.IntersectsWith(Pared17.Bounds))
            {
                PinkySpeed = -PinkySpeed;
            }

            Clyde.Top += ClydeSpeed;

            if (Clyde.Bounds.IntersectsWith(Pared35.Bounds) || Clyde.Bounds.IntersectsWith(Pared4.Bounds))
            {
                ClydeSpeed = -ClydeSpeed;
            }


        }
        private void SuperPastillaComida()
        {
            ModoPastilla = true; 
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox && (string)control.Tag == "Fantasmas")
                {
                    PictureBox fantasma = (PictureBox)control;
                    if (fantasma.Name == "Blinky")
                    {
                        fantasma.Image = Properties.Resources.FantasmaAsustado;
                    }
                    else if (fantasma.Name == "Pinky")
                    {
                        fantasma.Image = Properties.Resources.FantasmaAsustado;
                    }
                    else if (fantasma.Name == "Inky")
                    {
                        fantasma.Image = Properties.Resources.FantasmaAsustado;
                    }
                    else if (fantasma.Name == "Clyde")
                    {
                        fantasma.Image = Properties.Resources.FantasmaAsustado;
                    }
                }
            }

            
            Timer timerRevertirImagenes = new Timer();
            timerRevertirImagenes.Interval = 8000;
            timerRevertirImagenes.Tick += (sender, e) =>
           
            {
                ModoPastilla = false;
                
                foreach (Control control in this.Controls)
                {
                    if (control is PictureBox && (string)control.Tag == "Fantasmas")
                    {
                        PictureBox fantasma = (PictureBox)control;
                        if (fantasma.Name == "Blinky")
                        {
                            fantasma.Image = imagenOriginalBlinky;
                        }
                        else if (fantasma.Name == "Pinky")
                        {
                            fantasma.Image = imagenOriginalPinky;
                        }
                        else if (fantasma.Name == "Inky")
                        {
                            fantasma.Image = imagenOriginalInky;
                        }
                        else if (fantasma.Name == "Clyde")
                        {
                            fantasma.Image = imagenOriginalClyde;
                        }
                    }
                }

                timerRevertirImagenes.Stop(); 
            };

            timerRevertirImagenes.Start(); 

            
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox && (string)control.Tag == "Fantasmas")
                {
                    PictureBox fantasma = (PictureBox)control;
                    if (PacMan.Bounds.IntersectsWith(fantasma.Bounds))
                    {
                        
                    }
                }
            }
        }

        private void RestarVidas()
        {
            Vidas -= 1; 
            PacMan.Left = 31;
            PacMan.Top = 46;

            if (Vidas == 0)
            {
                 TimerPkman.Stop(); 
                gameOverLose(); 
            }

            else
            {
                TimerPkman.Start();
            }
        }


        private void gameOverWin()
        {
            isGameOver = true;
            TimerPkman.Stop();


            MessageBox.Show("Felicidades, has completado el juego", "¡Victoria!", MessageBoxButtons.OK);
            this.Dispose(); 
        }

        private void gameOverLose() 
        {
            isGameOver = true;
            TimerPkman.Stop();

            MessageBox.Show("Has perdido, mejor suerte la próxima vez", "Juego terminado", MessageBoxButtons.OK);
            this.Dispose(); 
        }



        private void CheckFinJuego()
        {
            bool todasMonedasRecogidas = true;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Moneda" && x.Visible)
                {
                    todasMonedasRecogidas = false;
                    break;
                }
            }

            if (todasMonedasRecogidas)
            {
                
                gameOverWin();
            }
        }


        private void VentanaPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            VerificadorTeclasPresionadas verificador = new VerificadorTeclasPresionadas(direccionPacman);
            verificador.Verificador(sender, e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Pared2_Click(object sender, EventArgs e)
        {

        }

        private void Pared3_Click(object sender, EventArgs e)
        {

        }

        private void Pared4_Click(object sender, EventArgs e)
        {

        }

        private void Pared8_Click(object sender, EventArgs e)
        {

        }

        private void Pared3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Pared20_Click(object sender, EventArgs e)
        {

        }

        private void Pared22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {

        }

        private void Pared23_Click(object sender, EventArgs e)
        {

        }

        private void Pared24_Click(object sender, EventArgs e)
        {

        }

        private void Pared21_Click(object sender, EventArgs e)
        {

        }

        private void Pared11_Click(object sender, EventArgs e)
        {

        }

        private void Pared15_Click(object sender, EventArgs e)
        {

        }

        private void Pared14_Click(object sender, EventArgs e)
        {

        }

        private void Pared18_Click(object sender, EventArgs e)
        {

        }

        private void Pared30_Click(object sender, EventArgs e)
        {

        }

        private void Pared28_Click(object sender, EventArgs e)
        {

        }

        private void Pared5_Click(object sender, EventArgs e)
        {

        }

        private void Pared29_Click(object sender, EventArgs e)
        {

        }

        private void Pared12_Click(object sender, EventArgs e)
        {

        }

        private void Pared13_Click(object sender, EventArgs e)
        {

        }

        private void Pared17_Click(object sender, EventArgs e)
        {

        }

        private void Pared19_Click(object sender, EventArgs e)
        {

        }

        private void Pared36_Click(object sender, EventArgs e)
        {

        }

        private void Pared33_Click(object sender, EventArgs e)
        {

        }

        private void Pared27_Click(object sender, EventArgs e)
        {

        }

        private void Pared37_Click(object sender, EventArgs e)
        {

        }

        private void Pared25_Click(object sender, EventArgs e)
        {

        }

        private void Pared32_Click(object sender, EventArgs e)
        {

        }

        private void Pared31_Click(object sender, EventArgs e)
        {

        }

        private void Pared34_Click(object sender, EventArgs e)
        {

        }

        private void Pared2_Click_1(object sender, EventArgs e)
        {

        }

        private void Pared35_Click(object sender, EventArgs e)
        {

        }

        private void Pared1_Click(object sender, EventArgs e)
        {

        }

        private void Barrera_Click(object sender, EventArgs e)
        {

        }

        private void Pared16_Click(object sender, EventArgs e)
        {

        }

        private void Clide_Click(object sender, EventArgs e)
        {

        }

        private void timerFantasmas_Tick(object sender, EventArgs e)
        {
        
            TMRSuperPastilla.Stop(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox97_Click(object sender, EventArgs e)
        {

        }

        private void Clyde_Click(object sender, EventArgs e)
        {

        }

     }
} 
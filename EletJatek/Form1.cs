using EletJatek;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Timer;
using static EletJatek.Mezo;

namespace EletJatek
{
    public partial class Form1 : Form
    {
        private Jatek jatek;
        public Label[,] palya;
        public Button lepes;
        public Button timer;
        private Timer timer1;
        public Form1()
        {
            InitializeComponent();
            Size = new Size(1000, 800);
        }

        public void Start_timer(object sender, EventArgs e)
        {
            Meret.Enabled = false;
            OKGomb.Enabled = false;
            lepes.Enabled = false;
            InitTimer();
        }

        public void Stop_timer(object sender, EventArgs e)
        {
            Meret.Enabled = true;
            OKGomb.Enabled = true;
            lepes.Enabled = true;
            timer1.Stop();
        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 500;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            jatek.Vmi = true;
            tablaUpdate();
        }

        private void Start(object sender, EventArgs e)
        {
            panelGame.Controls.Clear();
            int sor = Convert.ToInt32(Meret.Value);
            int oszlop = Convert.ToInt32(Meret.Value);

            jatek = new Jatek(sor, oszlop);
            palya = new Label[sor+2, oszlop+2];
            tablaMegj();
        }

        private void Gombok()
        {
            lepesGomb();
            timergomb1();
            timergomb2();
        }

        private void lepesGomb()
        {
            lepes = new Button();
            lepes.Text = "Next";
            lepes.Parent = controlPanel;
            lepes.Click += lepesGomb_Click;
            lepes.BackColor = Color.LightGray;
            lepes.Left = 50;
            lepes.Top = 20;
            controlPanel.Controls.Add(lepes);
        }

        private void timergomb1()
        {
            timer = new Button();
            timer.Text = "Start";
            timer.Parent = controlPanel;
            timer.Click += Start_timer;
            timer.BackColor = Color.LightGray;
            timer.Left = 150;
            timer.Top = 20;
            controlPanel.Controls.Add(timer);
        }

        private void timergomb2()
        {
            timer = new Button();
            timer.Text = "Stop";
            timer.Parent = controlPanel;
            timer.Click += Stop_timer;
            timer.BackColor = Color.LightGray;
            timer.Left = 250;
            timer.Top = 20;
            controlPanel.Controls.Add(timer);
        }

        private void lepesGomb_Click(object sender, EventArgs e)
        {
            jatek.Vmi = true;
            tablaUpdate();
        }

        private void tablaMegj()
        {
            int w = 500 / jatek.SorDb, h = 500 / jatek.SorDb;
            for (int i = 1; i < jatek.SorDb+1; i++)
            {
                for (int j = 1; j < jatek.OszlopDb+1; j++)
                {
                    Label lb = new Label()
                    {
                        Text = "",
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Courier New", 12, FontStyle.Bold),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.LightGray,
                        Cursor = Cursors.Hand,
                        Width = w,
                        Height = h,
                        Left = 100 + (j - 1) * w - (j - 1),
                        Top = 150 + (i - 2) * h - (i - 1),
                        Parent = panelGame,
                    };

                    if (jatek.tabla[i,j].Jel == Mezo.Jelek.Ures)
                    {
                        lb.BackColor = Color.LightGray;
                    }
                    else if (jatek.tabla[i, j].Jel == Mezo.Jelek.Foglalt)
                    {
                        lb.BackColor= Color.LightYellow;
                    }
                    palya[i, j] = lb;
                }
            }
            Gombok();
        }
        private void tablaUpdate()
        {
            for (int i = 1; i < jatek.SorDb+1; i++)
            {
                for (int j = 1; j < jatek.OszlopDb+1; j++)
                {
                    if (jatek.tabla[i, j].Jel == Mezo.Jelek.Ures)
                    {
                        palya[i,j].BackColor = Color.LightGray;
                    }
                    else if (jatek.tabla[i, j].Jel == Mezo.Jelek.Foglalt)
                    {
                        palya[i, j].BackColor = Color.LightYellow;
                    }
                }
            }
        }
    }
}
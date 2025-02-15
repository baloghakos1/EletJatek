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
        public Button timer_start;
        public Button timer_stop;
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
            timer_start.Enabled = false;
            timer_stop.Enabled = true;
            timer1.Start();
        }

        public void Stop_timer(object sender, EventArgs e)
        {
            Meret.Enabled = true;
            OKGomb.Enabled = true;
            lepes.Enabled = true;
            timer_start.Enabled = true;
            timer_stop.Enabled = false;
            timer1.Stop();
        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 300;
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
            timer_start = new Button();
            timer_start.Text = "Start";
            timer_start.Parent = controlPanel;
            timer_start.Click += Start_timer;
            timer_start.BackColor = Color.LightGray;
            timer_start.Left = 150;
            timer_start.Top = 20;
            controlPanel.Controls.Add(timer_start);
        }

        private void timergomb2()
        {
            timer_stop = new Button();
            timer_stop.Text = "Stop";
            timer_stop.Parent = controlPanel;
            timer_stop.Click += Stop_timer;
            timer_stop.BackColor = Color.LightGray;
            timer_stop.Left = 250;
            timer_stop.Top = 20;
            timer_stop.Enabled = false;
            controlPanel.Controls.Add(timer_stop);
        }

        private void changeColor(object sender, EventArgs e)
        {
            Label label = sender as Label;
            int[] asd = { (label.Tag as Info).Sor, (label.Tag as Info).Oszlop };
            jatek.Vmi1 = asd;
            tablaUpdate();
        }

        private void lepesGomb_Click(object sender, EventArgs e)
        {
            jatek.Vmi = true;
            tablaUpdate();
        }

        private void tablaMegj()
        {
            controlPanel.Controls.Remove(timer_start);
            controlPanel.Controls.Remove(timer_stop);
            controlPanel.Controls.Remove(lepes);
            int w = 500 / jatek.SorDb+2, h = 500 / jatek.SorDb+2;
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
                        Tag = new Info(i, j),
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
                        lb.BackColor= Color.Yellow;
                    }
                    lb.Click += changeColor;
                    palya[i, j] = lb;
                }
            }
            InitTimer();
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
                        palya[i, j].BackColor = Color.Yellow;
                    }
                }
            }
        }
    }
}
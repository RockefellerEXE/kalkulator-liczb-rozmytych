using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LICZBY_ROZMYTE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            czysc();
            chartWykres.Titles.Add("Kalkulator skierowanych liczb rozmytych").Font = new System.Drawing.Font("Microsoft Sans Serif", 8);
        }
        double dokladnosc = 1000;
        double y1 = 0;
        double y2 = 1;
        double y3 = 1;
        double y4 = 0;
        string err = "Wprowadź prawidłowe wartości.";
        string errA = "\nNiewłaściwe wartości w OFN A";
        string errB = "\nNiewłaściwe wartości w OFN B";
        string errN = "\nNiewłaściwe wartości w n";
        string err0 = "\nNie można dzielić przez 0";

        private void wstawA(double a1, double a2, double a3, double a4)
        {

            chartWykres.Series.Add("OFN A");
            chartWykres.Series["OFN A"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartWykres.Series["OFN A"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartWykres.Series["OFN A"].Color = System.Drawing.Color.Red;
            chartWykres.Series["OFN A"].BorderWidth = 5;
            chartWykres.Series["OFN A"].Points.AddXY(a1, y1);
            chartWykres.Series["OFN A"].Points.AddXY(a2, y2);
            chartWykres.Series["OFN A"].Points.AddXY(a3, y3);
            chartWykres.Series["OFN A"].Points.AddXY(a4, y4);
            chartWykres.Series.Add("Skierowanie A");
            chartWykres.Series["Skierowanie A"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
            chartWykres.Series["Skierowanie A"].Color = System.Drawing.Color.Red;
            chartWykres.Series["Skierowanie A"].Points.AddXY(a1, y1);
            chartWykres.ChartAreas[0].AxisX.RoundAxisValues();
            


        }
        private void wstawB(double a1, double a2, double a3, double a4)
        {

            chartWykres.Series.Add("OFN B");
            chartWykres.Series["OFN B"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartWykres.Series["OFN B"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartWykres.Series["OFN B"].Color = System.Drawing.Color.Blue;
            chartWykres.Series["OFN B"].BorderWidth = 5;
            chartWykres.Series["OFN B"].Points.AddXY(a1, y1);
            chartWykres.Series["OFN B"].Points.AddXY(a2, y2);
            chartWykres.Series["OFN B"].Points.AddXY(a3, y3);
            chartWykres.Series["OFN B"].Points.AddXY(a4, y4);
            chartWykres.Series.Add("Skierowanie B");
            chartWykres.Series["Skierowanie B"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
            chartWykres.Series["Skierowanie B"].Color = System.Drawing.Color.Blue;
            chartWykres.Series["Skierowanie B"].Points.AddXY(a1, y1);
            chartWykres.ChartAreas[0].AxisX.RoundAxisValues();
            //
            chartWykres.ChartAreas[0].AxisY.Minimum = 0;
            chartWykres.ChartAreas[0].AxisY.Maximum = 1;


        }
        private void wstawWynik(double a1, double a2, double a3, double a4, string flaga)
        {
            
            double[] OFNA1 = new double[(int)dokladnosc];
            double[] OFNB1 = new double[(int)dokladnosc];
            double[] OFNA2 = new double[(int)dokladnosc];
            double[] OFNB2 = new double[(int)dokladnosc];
            double[] Y1 = new double[(int)dokladnosc];
            double[] Y2 = new double[(int)dokladnosc];
            double rozA1, rozB1, rozA2, rozB2, rozy;
            if (flaga == "*" || flaga == "/") 
            {
                rozA1 = (double.Parse(A2.Text) - double.Parse(A1.Text)) / dokladnosc;
                rozB1 = (double.Parse(B2.Text) - double.Parse(B1.Text)) / dokladnosc;
                rozA2 = (double.Parse(A4.Text) - double.Parse(A3.Text)) / dokladnosc;
                rozB2 = (double.Parse(B4.Text) - double.Parse(B3.Text)) / dokladnosc;
                rozy = 1 / dokladnosc;
                for (int x = 0; x < dokladnosc - 1; x++)
                {
                    OFNA1[x] = double.Parse(A1.Text) + rozA1 * (x + 1);
                    OFNB1[x] = double.Parse(B1.Text) + rozB1 * (x + 1);
                    OFNA2[x] = double.Parse(A3.Text) + rozA2 * (x + 1);
                    OFNB2[x] = double.Parse(B3.Text) + rozB2 * (x + 1);
                    Y1[x] = y1 + rozy * (x + 1);
                    Y2[x] = y3 - rozy * (x + 1);
                }
            }
            

            chartWykres.Series.Add("Wynik");
            chartWykres.Series["Wynik"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartWykres.Series["Wynik"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartWykres.Series["Wynik"].Color = System.Drawing.Color.Green;
            chartWykres.Series["Wynik"].BorderWidth = 5;
            chartWykres.Series["Wynik"].Points.AddXY(a1, y1);
            if (flaga == "*") 
            {
                for (int x = 0; x < dokladnosc - 1; x++)
                {
                    chartWykres.Series["Wynik"].Points.AddXY(OFNA1[x] * OFNB1[x], Y1[x]);
                }
            }
            if (flaga == "/")
            {
                for (int x = 0; x < dokladnosc - 1; x++)
                {
                    chartWykres.Series["Wynik"].Points.AddXY(OFNA1[x] / OFNB1[x], Y1[x]);
                }
            }
            
            chartWykres.Series["Wynik"].Points.AddXY(a2, y2);
            chartWykres.Series["Wynik"].Points.AddXY(a3, y3);
            if (flaga == "*") 
            {
                for (int x = 0; x < dokladnosc - 1; x++)
                {
                    chartWykres.Series["Wynik"].Points.AddXY(OFNA2[x] * OFNB2[x], Y2[x]);
                }
            }
            if (flaga == "/")
            {
                for (int x = 0; x < dokladnosc - 1; x++)
                {
                    chartWykres.Series["Wynik"].Points.AddXY(OFNA2[x] / OFNB2[x], Y2[x]);
                }
            }
            
            chartWykres.Series["Wynik"].Points.AddXY(a4, y4);
            chartWykres.Series.Add("Skierowanie wyniku");
            chartWykres.Series["Skierowanie wyniku"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
            chartWykres.Series["Skierowanie wyniku"].Color = System.Drawing.Color.Green;
            chartWykres.Series["Skierowanie wyniku"].Points.AddXY(a1, y1);
            chartWykres.ChartAreas[0].AxisX.RoundAxisValues();
            chartWykres.ChartAreas[0].AxisY.Minimum = 0;
            chartWykres.ChartAreas[0].AxisY.Maximum = 1;
            chartWykres.ChartAreas[0].AxisY.Interval = 1;
            chartWykres.ChartAreas[0].AxisX.IntervalAutoMode= System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartWykres.ChartAreas[0].AxisX.ScaleBreakStyle.Enabled = true;
            //chartWykres.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //chartWykres.ChartAreas[0].AxisY.ScaleView.Zoomable = true;


        }
        
        private void zamien()
        {
            string buf1, buf2, buf3, buf4;
            buf1 = A1.Text;
            buf2 = A2.Text;
            buf3 = A3.Text;
            buf4 = A4.Text;
            A1.Text = B1.Text;
            A2.Text = B2.Text;
            A3.Text = B3.Text;
            A4.Text = B4.Text;
            B1.Text = buf1;
            B2.Text = buf2;
            B3.Text = buf3;
            B4.Text = buf4;
        }
        private void czysc()
        {
            chartWykres.Series.Clear();
            
        }
        private bool sprawdzA()
        {
            if(A1.Text == "" || A2.Text == "" || A3.Text == "" || A4.Text == "")
            {
                return false;
            }
            string x1, x2, x3, x4;
            double y1, y2, y3, y4;
            x1 = A1.Text;
            x2 = A2.Text;
            x3 = A3.Text;
            x4 = A4.Text;
            try
            {
                y1 = double.Parse(x1);
                y2 = double.Parse(x2);
                y3 = double.Parse(x3);
                y4 = double.Parse(x4);
            }
            catch
            {
                return false;
            }
            return true;
        }
        private bool sprawdzB()
        {
            if (B1.Text == "" || B2.Text == "" || B3.Text == "" || B4.Text == "")
            {
                return false;
            }
            string x1, x2, x3, x4;
            double y1, y2, y3, y4;
            x1 = B1.Text;
            x2 = B2.Text;
            x3 = B3.Text;
            x4 = B4.Text;
            try
            {
                y1 = double.Parse(x1);
                y2 = double.Parse(x2);
                y3 = double.Parse(x3);
                y4 = double.Parse(x4);
            }
            catch
            {
                return false;
            }
            return true;
        }
        private bool sprawdzN()
        {
            if (N.Text == "")
            {
                return false;
            }
            string x1;
            double y1;
            x1 = N.Text;
            
            try
            {
                y1 = double.Parse(x1);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void AsB_Click(object sender, EventArgs e)
        {
            if(sprawdzA() && sprawdzB())
            {
                W1.Text = (double.Parse(A1.Text) + double.Parse(B1.Text)).ToString();
                W2.Text = (double.Parse(A2.Text) + double.Parse(B2.Text)).ToString();
                W3.Text = (double.Parse(A3.Text) + double.Parse(B3.Text)).ToString();
                W4.Text = (double.Parse(A4.Text) + double.Parse(B4.Text)).ToString();
                czysc();
                wstawA(double.Parse(A1.Text), double.Parse(A2.Text), double.Parse(A3.Text), double.Parse(A4.Text));
                wstawB(double.Parse(B1.Text), double.Parse(B2.Text), double.Parse(B3.Text), double.Parse(B4.Text));
                wstawWynik(double.Parse(W1.Text), double.Parse(W2.Text), double.Parse(W3.Text), double.Parse(W4.Text),"");
                
                
            }
            else
            {
                string errmessage = err;
                if (!sprawdzA())
                {
                    errmessage += errA;
                }
                if (!sprawdzB())
                {
                    errmessage += errB;
                }
                MessageBox.Show(errmessage);
            }
        }

        private void ArB_Click(object sender, EventArgs e)
        {
            if (sprawdzA() && sprawdzB())
            {
                W1.Text = (double.Parse(A1.Text) - double.Parse(B1.Text)).ToString();
                W2.Text = (double.Parse(A2.Text) - double.Parse(B2.Text)).ToString();
                W3.Text = (double.Parse(A3.Text) - double.Parse(B3.Text)).ToString();
                W4.Text = (double.Parse(A4.Text) - double.Parse(B4.Text)).ToString();
                czysc();
                wstawA(double.Parse(A1.Text), double.Parse(A2.Text), double.Parse(A3.Text), double.Parse(A4.Text));
                wstawB(double.Parse(B1.Text), double.Parse(B2.Text), double.Parse(B3.Text), double.Parse(B4.Text));
                wstawWynik(double.Parse(W1.Text), double.Parse(W2.Text), double.Parse(W3.Text), double.Parse(W4.Text),"");
            }
            else
            {
                string errmessage = err;
                if (!sprawdzA())
                {
                    errmessage += errA;
                }
                if (!sprawdzB())
                {
                    errmessage += errB;
                }
                MessageBox.Show(errmessage);
            }

        }

        private void AmN_Click(object sender, EventArgs e)
        {

            if (sprawdzA() && sprawdzN())
            {
                W1.Text = (double.Parse(A1.Text) * double.Parse(N.Text)).ToString();
                W2.Text = (double.Parse(A2.Text) * double.Parse(N.Text)).ToString();
                W3.Text = (double.Parse(A3.Text) * double.Parse(N.Text)).ToString();
                W4.Text = (double.Parse(A4.Text) * double.Parse(N.Text)).ToString();
                czysc();
                wstawA(double.Parse(A1.Text), double.Parse(A2.Text), double.Parse(A3.Text), double.Parse(A4.Text));
                wstawWynik(double.Parse(W1.Text), double.Parse(W2.Text), double.Parse(W3.Text), double.Parse(W4.Text),"");
            }
            else
            {
                string errmessage = err;
                if (!sprawdzA())
                {
                    errmessage += errA;
                }
                if (!sprawdzN())
                {
                    errmessage += errN;
                }
                MessageBox.Show(errmessage);
            }
        }

        private void AdN_Click(object sender, EventArgs e)
        {
            if (N.Text != "0")
            {
                if (sprawdzA() && sprawdzN())
                {
                    W1.Text = (double.Parse(A1.Text) / double.Parse(N.Text)).ToString();
                    W2.Text = (double.Parse(A2.Text) / double.Parse(N.Text)).ToString();
                    W3.Text = (double.Parse(A3.Text) / double.Parse(N.Text)).ToString();
                    W4.Text = (double.Parse(A4.Text) / double.Parse(N.Text)).ToString();
                    czysc();
                    wstawA(double.Parse(A1.Text), double.Parse(A2.Text), double.Parse(A3.Text), double.Parse(A4.Text));
                    wstawWynik(double.Parse(W1.Text), double.Parse(W2.Text), double.Parse(W3.Text), double.Parse(W4.Text),"");
                }
                else
                {
                    string errmessage = err;
                    if (!sprawdzA())
                    {
                        errmessage += errA;
                    }
                    if (!sprawdzN())
                    {
                        errmessage += errN;
                    }
                    MessageBox.Show(errmessage);
                }
            }
            else
            {
                MessageBox.Show(err0);
            }
        }

        private void AmB_Click(object sender, EventArgs e)
        {
            if (sprawdzA() && sprawdzB())
            {
                W1.Text = (double.Parse(A1.Text) * double.Parse(B1.Text)).ToString();
                W2.Text = (double.Parse(A2.Text) * double.Parse(B2.Text)).ToString();
                W3.Text = (double.Parse(A3.Text) * double.Parse(B3.Text)).ToString();
                W4.Text = (double.Parse(A4.Text) * double.Parse(B4.Text)).ToString();
                czysc();
                wstawA(double.Parse(A1.Text), double.Parse(A2.Text), double.Parse(A3.Text), double.Parse(A4.Text));
                wstawB(double.Parse(B1.Text), double.Parse(B2.Text), double.Parse(B3.Text), double.Parse(B4.Text));
                wstawWynik(double.Parse(W1.Text), double.Parse(W2.Text), double.Parse(W3.Text), double.Parse(W4.Text),"*");
            }
            else
            {
                string errmessage = err;
                if (!sprawdzA())
                {
                    errmessage += errA;
                }
                if (!sprawdzB())
                {
                    errmessage += errB;
                }
                MessageBox.Show(errmessage);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zamien();

        }

        private void AdB_Click(object sender, EventArgs e)
        {
            if (B1.Text != "0" && B2.Text != "0" && B3.Text != "0" && B4.Text != "0")
            {
                if (sprawdzA() && sprawdzB())
                {
                    W1.Text = (double.Parse(A1.Text) / double.Parse(B1.Text)).ToString();
                    W2.Text = (double.Parse(A2.Text) / double.Parse(B2.Text)).ToString();
                    W3.Text = (double.Parse(A3.Text) / double.Parse(B3.Text)).ToString();
                    W4.Text = (double.Parse(A4.Text) / double.Parse(B4.Text)).ToString();
                    czysc();
                    wstawA(double.Parse(A1.Text), double.Parse(A2.Text), double.Parse(A3.Text), double.Parse(A4.Text));
                    wstawB(double.Parse(B1.Text), double.Parse(B2.Text), double.Parse(B3.Text), double.Parse(B4.Text));
                    wstawWynik(double.Parse(W1.Text), double.Parse(W2.Text), double.Parse(W3.Text), double.Parse(W4.Text),"/");
                }
                else
                {
                    string errmessage = err;
                    if (!sprawdzA())
                    {
                        errmessage += errA;
                    }
                    if (!sprawdzB())
                    {
                        errmessage += errB;
                    }
                    MessageBox.Show(errmessage);
                }
            }
            else
            {
                MessageBox.Show(errB+err0);
            }

        }

    }
}

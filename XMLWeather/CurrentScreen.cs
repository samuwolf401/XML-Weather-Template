using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            tempLabel.Text = $"{Form1.days[0].currentTemp}C°";
            minOutput.Text = $"{Form1.days[0].tempLow}C°";
            maxOutput.Text = $"{Form1.days[0].tempHigh}C°";
            dateLabel.Text = $"{DateTime.Now.DayOfWeek}" + " The " + $"{DateTime.Now.Day}";
            yearLabel.Text = $"{DateTime.Now.Month}" + " / " + $"{DateTime.Now.Year}";
            weatherOutput.Text = $"{Form1.days[0].condition}";
            if (Form1.days[0].code > 800)
            {
                this.BackColor = Color.DimGray;
            }
            else if (Form1.days[0].code == 800)
            {
                this.BackColor = Color.Yellow;
            }
            else if (Form1.days[0].code > 600)
            {
                this.BackColor = Color.Cyan;
            }
            else if (Form1.days[0].code > 300)
            {
                this.BackColor = Color.DodgerBlue;
            }
            else if (Form1.days[0].code > 200)
            {
                this.BackColor = Color.SlateGray;
            }

        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void searchInput_Click(object sender, EventArgs e)
        {
            Form1.city = cityInput.Text;
            Form1.ExtractCurrent();
            DisplayCurrent();
        }
    }
}

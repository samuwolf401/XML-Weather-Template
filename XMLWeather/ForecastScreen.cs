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
    public partial class ForecastScreen : UserControl
    {
        string currentDay;
        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            // output all the information
            ChangeDay();
            date1.Text = currentDay;
            min1.Text = $"{Form1.days[1].tempLow}C°";
            max1.Text = $"{Form1.days[1].tempHigh}C°";
            type1.Text = $"{Form1.days[1].precipitation}";

            ChangeDay();
            date2.Text = currentDay;
            min2.Text = $"{Form1.days[2].tempLow}C°";
            max2.Text = $"{Form1.days[2].tempHigh}C°";
            type2.Text = $"{Form1.days[2].precipitation}";

            ChangeDay();
            date3.Text = currentDay;
            min3.Text = $"{Form1.days[3].tempLow}C°";
            max3.Text = $"{Form1.days[3].tempHigh}C°";
            type3.Text = $"{Form1.days[3].precipitation}";

            ChangeDay();
            date4.Text = currentDay;
            min4.Text = $"{Form1.days[4].tempLow}C°";
            max4.Text = $"{Form1.days[4].tempHigh}C°";
            type4.Text = $"{Form1.days[4].precipitation}";

            ChangeDay();
            date5.Text = currentDay;
            min5.Text = $"{Form1.days[5].tempLow}C°";
            max5.Text = $"{Form1.days[5].tempHigh}C°";
            type5.Text = $"{Form1.days[5].precipitation}";

            ChangeDay();
            date6.Text = currentDay;
            min6.Text = $"{Form1.days[6].tempLow}C°";
            max6.Text = $"{Form1.days[6].tempHigh}C°";
            type6.Text = $"{Form1.days[6].precipitation}";


        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }

        private void ChangeDay()
        {
            //switch the recorded date
            if (Form1.dayOfWeek >= 7)
            {
                Form1.dayOfWeek = 1;
            }
            else Form1.dayOfWeek++;


            switch (Form1.dayOfWeek)
            {
                case 1:
                    currentDay = "Monday";
                    break;
                case 2:
                    currentDay = "Tuesday";
                    break;
                case 3:
                    currentDay = "Wednesday";
                    break;
                case 4:
                    currentDay = "Thursday";
                    break;
                case 5:
                    currentDay = "Friday";
                    break;
                case 6:
                    currentDay = "Saturday";
                    break;
                case 7:
                    currentDay = "Sunday";
                    break;

            }
        }
        private void searchInput_Click(object sender, EventArgs e)
        {
            try
            {
                //find the city, find the information, and display it
                Form1.city = cityInput.Text;
                Form1.ExtractForecast();
                displayForecast();
            }
            catch
            {
                cityInput.Text = "error";
            }
        }
    }
}

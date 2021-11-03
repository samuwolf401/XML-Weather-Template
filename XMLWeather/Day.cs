using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLWeather
{
    public class Day
    {
        public string date, condition, location, 
            windSpeed, windDirection, precipitation, visibility,  currentTime, currentTemp, tempHigh, tempLow;
        public int code;
        public double probability;
        public Day()
        {
            date = condition = location = currentTime = tempHigh = tempLow = currentTemp =
                 windSpeed = windDirection = precipitation = visibility = "";
            code = 0;
            probability = 0;


        }
    }
}

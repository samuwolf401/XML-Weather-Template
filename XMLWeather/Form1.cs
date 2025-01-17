﻿///Sam Wolfgram
///Weather App
///Nov 3 2021
///An app that tracks the temperature and weather from an API database
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        // a list to hold day objects and other set up variables
        public static List<Day> days = new List<Day>();
        public static int dayOfWeek;
        public static string city = "Stratford,CA";

        public Form1()
        {
            InitializeComponent();

            ExtractForecast();
            ExtractCurrent();

            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        public static void ExtractForecast()
        {
            //finding the day of the week
            switch (Convert.ToString(DateTime.Now.DayOfWeek))
            {
                case "Monday":
                    dayOfWeek = 1;
                    break;
                case "Tuesday":
                    dayOfWeek = 2;
                    break;
                case "Wednesday":
                    dayOfWeek = 3;
                    break;
                case "Thursday":
                    dayOfWeek = 4;
                    break;
                case "Friday":
                    dayOfWeek = 5;
                    break;
                case "Saturday":
                    dayOfWeek = 6;
                    break;
                case "Sunday":
                    dayOfWeek = 7;
                    break;
            }
            //http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0
            string url = "http://api.openweathermap.org/data/2.5/forecast/daily?q=" + $"{city}" + "&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0";
            XmlReader reader = XmlReader.Create($"{url}");

            while (reader.Read())
            {
                Day newDay = new Day();
                //fill day with the information
                reader.ReadToFollowing("time");
                newDay.date = reader.GetAttribute("day");

                reader.ReadToFollowing("precipitation");
                newDay.probability = Convert.ToDouble(reader.GetAttribute("probability"));
                if (newDay.probability > 0)
                {
                    newDay.precipitation = reader.GetAttribute("type");
                }
                else newDay.precipitation = "";

                reader.ReadToFollowing("temperature");
                newDay.tempLow = Convert.ToDouble(reader.GetAttribute("min")).ToString("0");
                newDay.tempHigh = Convert.ToDouble(reader.GetAttribute("max")).ToString("0");


                //add the day
                days.Add(newDay);
            }
        }

        public static void ExtractCurrent()
        {
            //http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0
            // current info is not included in forecast file so we need to use this file to get it


            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=" + $"{city}" + "&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");


            //finding all the important information
            reader.ReadToFollowing("city");
            days[0].location = reader.GetAttribute("name");
            reader.ReadToFollowing("temperature");
            days[0].currentTemp = Convert.ToDouble(reader.GetAttribute("value")).ToString("0");
            days[0].tempLow = Convert.ToDouble(reader.GetAttribute("min")).ToString("0");
            days[0].tempHigh = Convert.ToDouble(reader.GetAttribute("max")).ToString("0");
            reader.ReadToFollowing("weather");
            days[0].code = Convert.ToInt32(reader.GetAttribute("number"));
            days[0].condition = reader.GetAttribute("value");
            // reader.ReadToFollowing("wind");
            //reader.ReadToFollowing("speed");
            // days[0].windSpeed = reader.GetAttribute("value");
            // reader.ReadToFollowing("direction");
            // days[0].windDirection = reader.GetAttribute("name");
        }


    }
}

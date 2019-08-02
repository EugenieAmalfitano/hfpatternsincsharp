using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherOMatic_Explicit
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the subject and observers
            WeatherData weatherData = new WeatherData();

            CurrentConditions conditions = new CurrentConditions(weatherData);
            Statistics statistics = new Statistics(weatherData);
            Forecast forecast = new Forecast(weatherData);

            // create the readings
            WeatherMeasurements readings = new WeatherMeasurements();
            readings.temperature = 80F;
            readings.humidity = 65F;
            readings.pressure = 29.92F; 
            readings.minTemp = 80F;
            readings.maxTemp = 80F;
            readings.avgTemp = 80F;
            weatherData.UpdateReadings(readings);

            // update
            readings.temperature = 82F;
            readings.humidity = 70F;
            readings.pressure = 30.0F;
            weatherData.UpdateReadings(readings);

            // update
            readings.temperature = 78F;
            readings.humidity = 90F;
            readings.pressure = 31.0F;
            weatherData.UpdateReadings(readings);

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherOMatic_Explicit
{
    class CurrentConditions : IDisplay, IObserver, IDisposable
    {
        private ISubject weatherData = null;
        private WeatherMeasurements readings = new WeatherMeasurements();

        public CurrentConditions(ISubject newWeatherData)
        {
            this.weatherData = newWeatherData;
            this.weatherData.Register(this);
        }

        private void UnRegister()
        {
            if (this.weatherData != null)
                this.weatherData.UnRegister(this);
        }

        #region IDisplay Members

        public void Display()
        {
            Console.WriteLine("Current conditions: {0}F degrees and {1}% humidity, pressure is {2} millibars.",
                this.readings.temperature, this.readings.humidity,this.readings.pressure);
        }

        #endregion

        #region IObserver Members

        public void Update(WeatherMeasurements newReadings)
        {
            this.readings = newReadings;
            Display();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.UnRegister();
        }
        
        #endregion
    }

    class Statistics : IDisplay, IObserver, IDisposable
    {
        private ISubject weatherData = null;
        private WeatherMeasurements readings = new WeatherMeasurements();

        public Statistics(ISubject newWeatherData)
        {
            this.weatherData = newWeatherData;
            this.weatherData.Register(this);
        }

        private void UnRegister()
        {
            if (this.weatherData != null)
                this.weatherData.UnRegister(this);
        }

        #region IDisplay Members

        public void Display()
        {
            Console.WriteLine("Temperature Statistics: Min {0} / Max {1} / Avg {2}",
                this.readings.minTemp, this.readings.maxTemp , this.readings.avgTemp);
        }

        #endregion

        #region IObserver Members

        public void Update(WeatherMeasurements newReadings)
        {
            this.readings = newReadings;
            Display();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    class Forecast : IDisplay, IObserver, IDisposable
    {
        private ISubject weatherData = null;
        private WeatherMeasurements readings = new WeatherMeasurements();

        public Forecast(ISubject newWeatherData)
        {
            this.weatherData = newWeatherData;
            this.weatherData.Register(this);
        }

        private void UnRegister()
        {
            if (this.weatherData != null)
                this.weatherData.UnRegister(this);
        }

        #region IDisplay Members

        public void Display()
        {
            string forecastMsg = "";
            if (this.readings.temperature > 80)  forecastMsg = "Watch for cooler, rainy weather.";
            else if (this.readings.temperature < 80) forecastMsg = "The weather is perfect.";
            else forecastMsg = "Weather is improving.";
            Console.WriteLine("The forecast is: " + forecastMsg); 
        }

        #endregion

        #region IObserver Members

        public void Update(WeatherMeasurements newReadings)
        {
            this.readings = newReadings;
            Display();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

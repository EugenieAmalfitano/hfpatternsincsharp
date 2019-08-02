using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherOMatic_Explicit
{
    // create readings as struct so new readings don't require many changes
    struct WeatherMeasurements
    {
        public float temperature;
        public float humidity;
        public float pressure;
        public float minTemp;
        public float maxTemp;
        public float avgTemp;
    }

    class WeatherData : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private WeatherMeasurements readings = new WeatherMeasurements();

        // for refined control over when observers are notified
        public void HasChanged()
        {
            Notify();
        }

        public void UpdateReadings(WeatherMeasurements newReadings)
        {
            this.readings = newReadings;
            if (this.readings.temperature > this.readings.maxTemp) this.readings.maxTemp = this.readings.temperature;
            if (this.readings.temperature < this.readings.minTemp) this.readings.minTemp = this.readings.temperature;
            this.readings.avgTemp = (this.readings.minTemp + this.readings.maxTemp) / 2;
            HasChanged();
        }

        #region ISubject Members

        public void Register(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void UnRegister(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in this.observers)
                observer.Update(this.readings);
        }

        #endregion
    }
}

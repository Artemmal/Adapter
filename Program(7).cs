using System;

namespace HW23Adapter
{
    abstract class Sensor
    {
        public virtual void DegreesInFahrenheit()
        {

        }
    }
    class FahrenheitSensor : Sensor
    {
        public override void DegreesInFahrenheit()
        {
            Console.WriteLine("Fahrenheit degrees");
        }
    }
    class CelsiusSensor
    {
        public void DegreesInCelsius()
        {
            Console.WriteLine("Celsius Degrees");
        }
    }
    class Adapter : Sensor
    {
        CelsiusSensor celsiusSensor;
        public Adapter(CelsiusSensor cs)
        {
            celsiusSensor = cs;
        }
        public override void DegreesInFahrenheit()
        {
            celsiusSensor.DegreesInCelsius();
        }
    }
    class ClientIndicatorOfTemperature
    {
        public void Indicate(Sensor sensor)
        {
            sensor.DegreesInFahrenheit();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ClientIndicatorOfTemperature client = new ClientIndicatorOfTemperature();
            FahrenheitSensor fahrenheitSensor = new FahrenheitSensor();
            client.Indicate(fahrenheitSensor);
            CelsiusSensor celsiusSensor = new CelsiusSensor();
            Sensor adapter = new Adapter(celsiusSensor);
            client.Indicate(adapter);
        }
    }
}

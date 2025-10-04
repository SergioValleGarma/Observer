using ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class TemperatureSensor : ISubject
    {
        private readonly List<IObserver> _observers;
        private float _temperature;

        public TemperatureSensor()
        {
            _observers = new List<IObserver>();
        }

        public float Temperature
        {
            get => _temperature;
            set
            {
                if (Math.Abs(_temperature - value) > 0.01f)
                {
                    _temperature = value;
                    _ = NotifyObserversAsync();
                }
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                Console.WriteLine($"Observador registrado: {observer.GetType().Name}");
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
                Console.WriteLine($"Observador removido: {observer.GetType().Name}");
            }
        }

        public async Task NotifyObserversAsync()
        {
            var tasks = new List<Task>();

            foreach (var observer in _observers)
            {
                tasks.Add(observer.UpdateAsync(_temperature));
            }

            await Task.WhenAll(tasks);
        }

        public async Task SimulateTemperatureChangesAsync()
        {
            var random = new Random();

            for (int i = 0; i < 15; i++)
            {
                Temperature = random.Next(15, 35) + (float)random.NextDouble();
                Console.WriteLine($"\n--- Temperatura cambiada a: {Temperature:F1}°C ---");
                await Task.Delay(5000);
            }
        }
    }
}

using System;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class LoggingSystem : IObserver
    {
        public async Task UpdateAsync(float temperature)
        {
            await Task.Delay(50);

            Console.WriteLine($"[LOG] {DateTime.Now:HH:mm:ss} - Temperatura registrada: {temperature:F1}°C");
        }
    }
}

using System;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class WebDashboard : IObserver
    {
        public async Task UpdateAsync(float temperature)
        {
            await Task.Delay(150);

            var status = temperature < 20 ? "❄️ Frío" : temperature < 28 ? "🌤 Normal" : "🔥 Caliente";
            Console.WriteLine($"[Web Dashboard] {temperature:F1}°C - Estado: {status}");
        }
    }
}
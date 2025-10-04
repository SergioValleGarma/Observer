using System;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class MobileDisplay : IObserver
    {
        private readonly string _deviceName;

        public MobileDisplay(string deviceName)
        {
            _deviceName = deviceName;
        }

        public async Task UpdateAsync(float temperature)
        {
            await Task.Delay(100);

            var alert = temperature > 30 ? " ⚠️ ALERTA: Temperatura alta!" : "";
            Console.WriteLine($"[Mobile - {_deviceName}] Temperatura actual: {temperature:F1}°C{alert}");
        }
    }
}

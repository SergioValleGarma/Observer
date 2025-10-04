using ObserverPattern;
using System;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("🔬 DEMOSTRACIÓN PATRÓN OBSERVER - SENSOR DE TEMPERATURA\n");

            // Crear el sujeto (observable)
            var temperatureSensor = new TemperatureSensor();

            // Crear observadores
            var mobileDisplay1 = new MobileDisplay("iPhone 13");
            var mobileDisplay2 = new MobileDisplay("Samsung Galaxy");
            var webDashboard = new WebDashboard();
            var loggingSystem = new LoggingSystem();

            // Registrar observadores
            temperatureSensor.RegisterObserver(mobileDisplay1);
            temperatureSensor.RegisterObserver(mobileDisplay2);
            temperatureSensor.RegisterObserver(webDashboard);
            temperatureSensor.RegisterObserver(loggingSystem);

            Console.WriteLine("\n🚀 Iniciando simulación de cambios de temperatura...\n");

            // Simular cambios
            await temperatureSensor.SimulateTemperatureChangesAsync();

            // Demostrar remoción de observador
            Console.WriteLine("\n--- Removiendo un observador ---");
            temperatureSensor.RemoveObserver(mobileDisplay2);

            // Un cambio más después de remover un observador
            Console.WriteLine("\n--- Cambio final después de remover observador ---");
            temperatureSensor.Temperature = 25.5f;
            await Task.Delay(1000);

            Console.WriteLine("\n🏁 Simulación completada!");
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
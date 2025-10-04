using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface IObserver
    {
        Task UpdateAsync(float temperature);
    }
}
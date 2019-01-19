using System.Threading;
using System.Threading.Tasks;

namespace UnhallowedStudios.Patterns.Harbinger.Events
{
    public interface IEventHandler<T> 
        where T : IEvent
    {
        Task ExecuteAsync(T @event, CancellationToken cancellationToken = default(CancellationToken));
    }
}
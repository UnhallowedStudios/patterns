using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnhallowedStudios.Patterns.Harbinger.Events
{
    public abstract class EventHandler<T, TRepository> :
        IEventHandler<T>
        where T : IEvent
        where TRepository : class
    {
        protected readonly TRepository _repository;
        public EventHandler(TRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task ExecuteAsync(T @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            return OnExecuteAsync(@event, cancellationToken);
        }

        protected abstract Task OnExecuteAsync(T @event, CancellationToken cancellationToken = default(CancellationToken));
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnhallowedStudios.Patterns.Harbinger.Events
{
    public abstract class EventHandlerDecorator<T, TRepository> :
        EventHandler<T, TRepository>
        where T : IEvent
        where TRepository : class
    {
        private readonly IEventHandler<T> _decorated;

        public EventHandlerDecorator(TRepository repository, IEventHandler<T> eventHandler) 
            : base(repository)
        {
            _decorated = eventHandler ?? throw new ArgumentNullException(nameof(eventHandler));
        }

        public new async Task ExecuteAsync(T @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            await OnExecuteAsync(@event, cancellationToken);

            await _decorated.ExecuteAsync(@event, cancellationToken);
        }
    }
}

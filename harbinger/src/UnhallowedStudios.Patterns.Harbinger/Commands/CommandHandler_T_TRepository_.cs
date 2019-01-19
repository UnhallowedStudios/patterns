using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnhallowedStudios.Patterns.Harbinger.Commands
{
    public abstract class CommandHandler<T, TRepository> :
        ICommandHandler<T>
        where T : ICommand
        where TRepository : class
    {
        protected readonly TRepository _repository;
        public CommandHandler(TRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task ExecuteAsync(T command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return OnExecuteAsync(command, cancellationToken);
        }

        protected abstract Task OnExecuteAsync(T command, CancellationToken cancellationToken = default(CancellationToken));
    }
}

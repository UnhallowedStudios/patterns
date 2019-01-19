using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnhallowedStudios.Patterns.Harbinger.Commands
{
    public abstract class CommandHandlerDecorator<T, TRepository> :
        CommandHandler<T, TRepository>
        where T : ICommand
        where TRepository : class
    {
        private readonly ICommandHandler<T> _decorated;

        public  CommandHandlerDecorator(TRepository repository, ICommandHandler<T> commandHandler)
            : base(repository)
        {
            _decorated = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
        }

        public new async Task ExecuteAsync(T command, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            await OnExecuteAsync(command, cancellationToken);

            await _decorated.ExecuteAsync(command, cancellationToken);
        }
    }
}

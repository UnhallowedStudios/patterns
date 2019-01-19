using System.Threading;
using System.Threading.Tasks;

namespace UnhallowedStudios.Patterns.Harbinger.Commands
{
    public interface ICommandHandler<T>
        where T : ICommand
    {
        Task ExecuteAsync(T command, CancellationToken cancellationToken = default(CancellationToken));
    }
}

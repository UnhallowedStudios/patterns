using System.Threading;
using System.Threading.Tasks;

namespace UnhallowedStudios.Patterns.Harbinger.Pipeline
{
    public interface IFilter<T>
    {
        Task<T> ExecuteAsync(T input, CancellationToken cancellationToken = default(CancellationToken));
        void Register(IFilter<T> filter, CancellationToken cancellationToken = default(CancellationToken));
    }
}

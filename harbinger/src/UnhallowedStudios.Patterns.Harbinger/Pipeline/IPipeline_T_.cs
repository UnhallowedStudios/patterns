using System.Threading;
using System.Threading.Tasks;

namespace UnhallowedStudios.Patterns.Harbinger.Pipeline
{
    public interface IPipeline<T>
    {
        Task<T> ExecuteAsync(T input, CancellationToken cancellationToken = default(CancellationToken));
        IPipeline<T> Register(IFilter<T> filter, CancellationToken cancellationToken = default(CancellationToken));
    }
}

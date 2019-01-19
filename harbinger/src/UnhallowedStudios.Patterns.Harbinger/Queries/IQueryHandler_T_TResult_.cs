using System.Threading;
using System.Threading.Tasks;

namespace UnhallowedStudios.Patterns.Harbinger.Queries
{
    public interface IQueryHandler<T, TResult>
        where T : IQuery
        where TResult : class
    {
        Task<TResult> ExecuteAsync(T query, CancellationToken cancellationToken = default(CancellationToken));
    }
}

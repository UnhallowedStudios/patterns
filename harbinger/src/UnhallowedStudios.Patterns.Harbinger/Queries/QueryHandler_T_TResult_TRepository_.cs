using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnhallowedStudios.Patterns.Harbinger.Queries
{
    public abstract class QueryHandler<T, TResult, TRepository> :
        IQueryHandler<T, TResult>
        where T : IQuery
        where TResult : class
        where TRepository : class
    {
        protected readonly TRepository _repository;
        public QueryHandler(TRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<TResult> ExecuteAsync(T query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return OnExecuteAsync(query, cancellationToken);
        }

        protected abstract Task<TResult> OnExecuteAsync(T query, CancellationToken cancellationToken = default(CancellationToken));
    }
}

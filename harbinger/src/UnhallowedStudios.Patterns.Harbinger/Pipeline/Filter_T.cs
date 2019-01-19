using System.Threading;
using System.Threading.Tasks;

namespace UnhallowedStudios.Patterns.Harbinger.Pipeline
{
    public abstract class Filter<T> :
        IFilter<T>
    {
        private IFilter<T> _next;

        protected abstract Task<T> OnExecuteAsync(T input);

        public async Task<T> ExecuteAsync(T input, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            T val = await OnExecuteAsync(input);
            if (_next != null) val = await _next.ExecuteAsync(val, cancellationToken);
            return val;
        }

        public void Register(IFilter<T> filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (_next == null) _next = filter;
            else _next.Register(filter);
        }
    }
}

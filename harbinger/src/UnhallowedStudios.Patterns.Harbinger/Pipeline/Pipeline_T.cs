using System.Threading;
using System.Threading.Tasks;

namespace UnhallowedStudios.Patterns.Harbinger.Pipeline
{
    public class Pipeline<T> :
        IPipeline<T>
    {
        private IFilter<T> _root;

        public async Task<T> ExecuteAsync(T input, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _root.ExecuteAsync(input, cancellationToken);
        }

        public IPipeline<T> Register(IFilter<T> filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (_root == null) _root = filter;
            else _root.Register(filter, cancellationToken);

            return this;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFilters
{
    /// <inheritdoc />
    public sealed class FilterService<TEnumerable, TData> : IFilterService<TEnumerable, TData> where TEnumerable : class, IEnumerable<TData>, new() where TData : class
	{
        private readonly List<IFilter<TEnumerable, TData>> _filters;

        public FilterService()
        {
            _filters = new List<IFilter<TEnumerable, TData>>();
        }

        /// <inheritdoc />
        public IFilterService<TEnumerable, TData> AddFilter<TFilterType>(BaseFilterProperties filterProperties = null) where TFilterType : IFilter<TEnumerable, TData>, new()
        {
            var filter = new TFilterType();

            filter.Initialize(filterProperties);

            _filters.Add(filter);

            return this;
        }

        /// <inheritdoc />
        public async Task<TEnumerable> ExecuteAsync(TEnumerable elements)
        {
            var copyOfElements = MakeCopyEnumerable(elements);

            foreach(var filter in _filters)
            {
                copyOfElements = await filter.ExecuteFilter(copyOfElements);
            }

            return copyOfElements;
        }

        private static TEnumerable MakeCopyEnumerable(TEnumerable elements)
        {
            var copyOfElements = new TEnumerable();

            foreach (var element in elements)
            {
                copyOfElements = copyOfElements.Append(element) as TEnumerable;
            }

            return copyOfElements;
        }
    }
}


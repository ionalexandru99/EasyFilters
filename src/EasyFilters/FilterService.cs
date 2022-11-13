namespace EasyFilters;

/// <inheritdoc />
public sealed class FilterService<TData> : IFilterService<TData> where TData : class
{
    private readonly List<IFilter<TData>> _filters = new();

    /// <inheritdoc />
    public IFilterService<TData> AddFilter<TFilterType>(BaseFilterProperties? filterProperties = null) where TFilterType : IFilter<TData>, new()
    {
        var filter = new TFilterType();

        filter.Initialize(filterProperties);

        _filters.Add(filter);

        return this;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TData>> ExecuteAsync(IEnumerable<TData> elements)
    {
        var copyOfElements = new List<TData>(elements);

        foreach (var filter in _filters.TakeWhile(_ => copyOfElements.Count != 0))
        {
            var result = await filter.ExecuteFilter(copyOfElements);
            copyOfElements = result.ToList();
        }

        return copyOfElements;
    }
}
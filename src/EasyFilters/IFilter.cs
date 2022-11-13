namespace EasyFilters;

public interface IFilter<TData> where TData : class
{
    /// <summary>
    /// Initializes the filter with the properties found in the object
    /// </summary>
    /// <param name="filterProperties">A class containing the requited properties for the filter. It can be any object extensions of the <see cref="BaseFilterProperties"/> class</param>
    void Initialize(BaseFilterProperties? filterProperties = null);

    /// <summary>
    /// Executes the filter logic on the received list, and returns an <see cref="IEnumerable{T}"/> containing the result after filtering.
    /// </summary>
    /// <param name="elements">An <see cref="IEnumerable{T}"/> containing all the elements that need to be filtered</param>
    /// <returns>An <see cref="IEnumerable{T}"/> with the data after applying the filter</returns>
    Task<IEnumerable<TData>> ExecuteFilter(IEnumerable<TData> elements);
}
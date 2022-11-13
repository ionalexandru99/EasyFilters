namespace EasyFilters;

/// <summary>
/// The core service used for filtering the data. In this service the implementations of the <see cref="IFilter{TData}"/> interface must be added.
/// </summary>
/// <typeparam name="TData">The data type contained in the <see cref="IEnumerable{T}"/> type</typeparam>
public interface IFilterService<TData> where TData : class
{
    /// <summary>
    /// Adds a new filter in the List of filters that the service has and initializes it with the received Filter Properties
    /// </summary>
    /// <typeparam name="TFilterType">An implementation of the <see cref="IFilter{TData}"/> interface that has the same <see cref="TData"/> type as the <see cref="IFilterService{TData}"/></typeparam>
    /// <param name="filterProperties">The properties that the mentioned filter should take into consideration when running</param>
    /// <returns>Returns the same instant of an object. Used for channing methods.</returns>
    IFilterService<TData> AddFilter<TFilterType>(BaseFilterProperties? filterProperties = null)
        where TFilterType : IFilter<TData>, new();

    /// <summary>
    /// Executes all the filters that are in the service List of filters. The filter are executed in the order they were added.
    /// </summary>
    /// <param name="elements">An <see cref="IEnumerable{T}"/> containing all the values for which the filters need to be applied</param>
    /// <returns></returns>
    Task<IEnumerable<TData>> ExecuteAsync(IEnumerable<TData> elements);
}
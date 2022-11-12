using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyFilters
{

    /// <summary>
    /// The core service used for filtering the data. In this service the implementations of the IFilter interface must be added.
    /// </summary>
    /// <typeparam name="TEnumarable">The type of IEnumarable for which the filtering is done. Ex: List, Dictionary.</typeparam>
    /// <typeparam name="TData">The data type contained in the IEnumarable type</typeparam>
    public interface IFilterService<TEnumarable, TData> where TEnumarable : IEnumerable<TData> where TData : class
    {
        /// <summary>
        /// Adds a new filter in the List of filters that the service has and initializes it with the received Filter Properties
        /// </summary>
        /// <typeparam name="TFilterType">An implementation of the IFilter interface that has the same TData type as the IFilterService</typeparam>
        /// <param name="filterProperties">The properties that the mentioned filter should take into consideration when running</param>
        /// <returns>Returns the same instant of an object. Used for chaning methods.</returns>
        IFilterService<TEnumarable, TData> AddFilter<TFilterType>(BaseFilterProperties filterProperties = null)
            where TFilterType : IFilter<TEnumarable, TData>, new();

        /// <summary>
        /// Executes all the filters that are in the service List of filters. The filter are executed in the order they were added.
        /// </summary>
        /// <param name="elements">An IEnumarable </param>
        /// <returns></returns>
        Task<TEnumarable> ExecuteAsync(TEnumarable elements);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyFilters
{
    public interface IFilter<TEnumarable, TData> where TEnumarable : IEnumerable<TData> where TData : class
    {
        /// <summary>
        /// Initializes the filter with the properties found in the object
        /// </summary>
        /// <param name="filterProperties">A class containing the requited properties for the filter</param>
        void Initialize(BaseFilterProperties filterProperties = null);

        /// <summary>
        /// Executes the filter logic on the received list, and returns an IEnumarable containing the result after filtering.
        /// </summary>
        /// <param name="elements">An IEnumarable containing all the elements that need to be filtered</param>
        /// <returns>An IEnumarable with the data after applying the filter</returns>
        Task<TEnumarable> ExecuteFilter(TEnumarable elements);
    }
}
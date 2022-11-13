using EasyFilters;

namespace TestApp.Filters.DateOfBirthFilters;

public class MustBeOverAgeYearsOldFilterProperties : BaseFilterProperties
{
    public int Age { get; set; }
}
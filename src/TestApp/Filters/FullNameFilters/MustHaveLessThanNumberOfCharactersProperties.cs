using EasyFilters;

namespace TestApp.Filters.FullNameFilters;

public class MustHaveLessThanNumberOfCharactersProperties : BaseFilterProperties
{
    public int MaxNumberOfCharacters { get; set; }
}
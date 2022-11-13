using EasyFilters;
using TestApp.Models;

namespace TestApp.Filters.DateOfBirthFilters;

public class MustBeOverAgeYearsOldFilter : IFilter<User>
{
    private int _age;
    
    public void Initialize(BaseFilterProperties? filterProperties = null)
    {
        if (filterProperties is not MustBeOverAgeYearsOldFilterProperties properties)
        {
            throw new InvalidCastException($"Provided filter properties class is not of type '{nameof(MustBeOverAgeYearsOldFilterProperties)}'");
        }

        _age = properties.Age;
    }

    public Task<IEnumerable<User>> ExecuteFilter(IEnumerable<User> elements)
    {
        var users = new List<User>(elements);

        users = users
            .Where(x => DateTime.Now >= x.DateOfBirth.AddYears(_age))
            .ToList();

        return Task.FromResult(users as IEnumerable<User>);
    }
}
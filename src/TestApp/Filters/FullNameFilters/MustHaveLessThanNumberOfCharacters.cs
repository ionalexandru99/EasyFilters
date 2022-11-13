using EasyFilters;
using TestApp.Models;

namespace TestApp.Filters.FullNameFilters;

public class MustHaveLessThanNumberOfCharacters : IFilter<User>
{
    private int _maxNumberOfCharacters;
    
    public void Initialize(BaseFilterProperties? filterProperties = null)
    {
        if (filterProperties is not MustHaveLessThanNumberOfCharactersProperties charactersProperties)
        {
            throw new InvalidCastException($"Provided filter properties class is not of type '{nameof(MustHaveLessThanNumberOfCharactersProperties)}'");
        }

        _maxNumberOfCharacters = charactersProperties.MaxNumberOfCharacters;
    }

    public Task<IEnumerable<User>> ExecuteFilter(IEnumerable<User> elements)
    {
        var users = new List<User>(elements);

        users = users
            .Where(user => user.FullName is null || user.FullName.Length <= _maxNumberOfCharacters)
            .ToList();

        return Task.FromResult(users as IEnumerable<User>);
    }
}
using EasyFilters;
using TestApp.Filters.DateOfBirthFilters;
using TestApp.Filters.FullNameFilters;
using TestApp.Models;

var users = new List<User>
{
    new(){ Id = 1, FullName = "Test1", DateOfBirth = DateTime.Now.AddYears(-19) },
    new(){ Id = 1, FullName = "Test20", DateOfBirth = DateTime.Now.AddYears(-20) },
    new(){ Id = 1, FullName = "Test300", DateOfBirth = DateTime.Now.AddYears(-17) },
    new(){ Id = 1, FullName = "Test4000", DateOfBirth = DateTime.Now.AddYears(-18).AddDays(1) },
    new(){ Id = 1, FullName = "Test50000", DateOfBirth = DateTime.Now.AddYears(-18).AddDays(-1) },
    new(){ Id = 1, FullName = "Test600000", DateOfBirth = DateTime.Now }
};

var filterService = new FilterService<User>();

var remainingUser = await filterService
    .AddFilter<MustBeOverAgeYearsOldFilter>(new MustBeOverAgeYearsOldFilterProperties {Age = 18})
    .AddFilter<MustHaveLessThanNumberOfCharacters>(new MustHaveLessThanNumberOfCharactersProperties { MaxNumberOfCharacters = 7 })
    .ExecuteAsync(users);

foreach (var user in remainingUser)
{
    Console.WriteLine(user.ToString());
}



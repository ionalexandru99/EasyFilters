using System.Text;

namespace TestApp.Models;

public class User
{
    public int Id { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? FullName { get; set; }

    public override string ToString()
    {
        return GetType().GetProperties()
            .Select(info => (info.Name, Value: info.GetValue(this, null) ?? "(null)"))
            .Aggregate(
                new StringBuilder(),
                (sb, pair) => sb.AppendLine($"{pair.Name}: {pair.Value}"),
                sb => sb.ToString());
    }
}
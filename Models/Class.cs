namespace AuthAPI.Models;

public class Class : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<Activity> Activities { get; set; } = [];
}

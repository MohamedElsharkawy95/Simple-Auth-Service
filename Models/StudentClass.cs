using AuthAPI.Enums;

namespace AuthAPI.Models;

public class StudentClass : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int ClassId { get; set; }
    public Class Class { get; set; } = null!;

    public ICollection<Activity> Activities { get; set; } = [];
}

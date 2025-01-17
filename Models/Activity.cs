using AuthAPI.Enums;

namespace AuthAPI.Models;

public class Activity : BaseEntity
{
    public ActivityType ActivityType { get; set; }
    public required string Description { get; set; }
    public required double Grade { get; set; }
    public required AttendanceStatus AttendanceStatus { get; set; }
    public DateTime Date { get; set; }

    public int StudentClassId { get; set; }
    public StudentClass StudentClass { get; set; } = null!;

    public ICollection<HomeworkFile> HomeworkFiles { get; set; } = [];
}

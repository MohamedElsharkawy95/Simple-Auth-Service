using System.Text.Json.Serialization;

namespace AuthAPI.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ActivityType : byte
{
    Attendance = 1,
    HomeWork = 2,
    Quiz = 3
}

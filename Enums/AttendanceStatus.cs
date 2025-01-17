using System.Text.Json.Serialization;

namespace AuthAPI.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AttendanceStatus : byte
{
    Absent,
    Present
}

using FoxPro.Enums;

namespace FoxPro.DTOs;

public class TaskDto
{
    public string Id { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public string Filename { get; set; }
    public string Class { get; set; }
    public string Method { get; set; }
    public int Line { get; set; }
    public string Contents { get; set; }
    public char Type { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; } = (int)PriorityEnum.LOW;
    public int Status { get; set; } = (int)StatusEnum.NotComplete;
}

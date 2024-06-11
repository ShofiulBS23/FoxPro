using FoxPro.Enums;
using System.ComponentModel.DataAnnotations;

namespace FoxPro.DTOs;

public class TaskDto
{
    public string Id { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    [Display(Name = "File Name")]
    public string Filename { get; set; }
    public string Class { get; set; }
    public string Method { get; set; }
    public int Line { get; set; }
    [Display(Name = "Contents")]
    [Required(ErrorMessage = "Contents is required")]
    public string Contents { get; set; }
    public char Type { get; set; }
    [Display(Name = "Due Date")]
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; } = DateTime.Now;
    public int Priority { get; set; } = (int)PriorityEnum.LOW;
    public int Status { get; set; } = (int)StatusEnum.NotComplete;

    public List<TaskDto> Tasks { get; set; }
}

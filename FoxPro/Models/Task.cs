using FoxPro.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FoxPro.Models;

[Table("Tasks")]
public class Task
{
    [Key]
    public string Id { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public string Filename { get; set; } = string.Empty;
    public string Class { get; set; } = String.Empty;
    public string Method { get; set; } = string.Empty ;
    public int Line { get; set; }
    public string Contents { get; set; } = string.Empty;
    public char Type { get; set; } = 'A';
    public DateTime DueDate { get; set; }
    public int Priority { get; set; } = (int)PriorityEnum.LOW;
    public int Status { get; set; } = (int) StatusEnum.NotComplete;
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoxPro.Models;

[Table("TaskLists")]
public class TaskList
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<Task> Tasks { get; set; } = new List<Task>();
    public string OrderByField { get; set; }
    public bool OrderAsc { get; set; }
    public string ShowTasks { get; set; }
    public DateTime LastUpdate { get; set; }
}


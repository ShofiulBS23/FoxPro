using FoxPro.Data;
using FoxPro.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace FoxPro.Services.Implementation;

public class TaskListService
{
    private List<Models.Task> tasks = new List<Models.Task>();
    private string dataSource = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "foxtask.dbf");
    private string orderByField = "duedate";
    private bool orderAscending = true;
    private string showTasks = "SCOU";

    // Use dependency injection for database context
    private readonly ApplicationDbContext _context;

    public TaskListService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task LoadTasksAsync()
    {
        tasks = await _context.Tasks.OrderBy(t => t.DueDate).ToListAsync();
    }

    public async Task AddTaskAsync(Models.Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTaskAsync(Models.Task task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveTaskAsync(int taskId)
    {
        var task = await _context.Tasks.FindAsync(taskId);
        if (task != null) {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}

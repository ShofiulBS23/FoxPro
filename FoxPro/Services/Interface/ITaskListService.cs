namespace FoxPro.Services.Interface;

public interface ITaskListService
{
    Task<List<Models.Task>> LoadTasksAsync();
    Task AddTaskAsync(Models.Task task);
    Task UpdateTaskAsync(Models.Task task);
    Task RemoveTaskAsync(string taskId);
    Task UpdateStatusAsync(string taskId);
}
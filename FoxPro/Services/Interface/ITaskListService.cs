namespace FoxPro.Services.Interface;

public interface ITaskListService
{
    Task LoadTasksAsync();
    Task AddTaskAsync(Models.Task task);
    Task UpdateTaskAsync(Models.Task task);
    Task RemoveTaskAsync(int taskId);
}
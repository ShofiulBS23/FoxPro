﻿using FoxPro.Data;
using FoxPro.Enums;
using FoxPro.Models;
using FoxPro.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace FoxPro.Services.Implementation;

public class TaskListService : ITaskListService
{
    public List<Models.Task> tasks = new List<Models.Task>();
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

    public async Task<List<Models.Task>> LoadTasksAsync()
    {
        return await _context.Tasks.OrderBy(t => t.DueDate).ToListAsync();
    }

    public async Task AddTaskAsync(Models.Task task)
    {
        try {
            task.Id = Guid.NewGuid().ToString();
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

        } catch (Exception ex)
        {
        }
    }

    public async Task UpdateTaskAsync(Models.Task task)
    {
        try {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        } catch (Exception ex) 
        {

        }
        
    }
    public async Task UpdateStatusAsync(string id)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (task != null) {
            task.Status = task.Status == 0 ? (int)StatusEnum.Complete : (int)StatusEnum.NotComplete;
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
        
    }

    public async Task RemoveTaskAsync(string taskId)
    {
        var task = await _context.Tasks.FindAsync(taskId);
        if (task != null) {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}

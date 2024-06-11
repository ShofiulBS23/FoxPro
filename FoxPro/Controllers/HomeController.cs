using FoxPro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FoxPro.Services.Interface;
using FoxPro.DTOs;
using AutoMapper;  // Ensure the namespace for TaskListService is correctly referenced

namespace FoxPro.Controllers;

public class HomeController : Controller
{
    public readonly ILogger<HomeController> _logger;
    private readonly ITaskListService _taskListService;  // Add TaskListService dependency
    private readonly IMapper _mapper;

    public HomeController(
        ILogger<HomeController> logger,
        ITaskListService taskListService,
        IMapper mapper
        )
    {
        _logger = logger;
        _taskListService = taskListService;  // Initialize through constructor injection
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var tasks = await _taskListService.LoadTasksAsync();  // Load tasks asynchronously
        TaskDto dto = new() {
            Tasks = _mapper.Map<List<TaskDto>>(tasks)
        };
        return View("Index", dto);  // Pass the tasks to the Index view
    }

    [HttpPost]
    public async Task<IActionResult> AddTask([FromBody] Models.Task task)
    {
        await _taskListService.AddTaskAsync(task);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTask([FromBody] Models.Task task)
    {
        await _taskListService.UpdateTaskAsync(task);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStatus([FromBody] Models.Task task)
    {
        await _taskListService.UpdateStatusAsync(task.Id);
        return RedirectToAction("Index");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTask(string taskId)
    {
        await _taskListService.RemoveTaskAsync(taskId);
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

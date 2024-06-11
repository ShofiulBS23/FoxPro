using FoxPro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FoxPro.Services.Implementation;  // Ensure the namespace for TaskListService is correctly referenced

namespace FoxPro.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger<HomeController> _logger;
        private readonly TaskListService _taskListService;  // Add TaskListService dependency

        public HomeController(ILogger<HomeController> logger, TaskListService taskListService)
        {
            _logger = logger;
            _taskListService = taskListService;  // Initialize through constructor injection
        }

        public async Task<IActionResult> Index()
        {
            await _taskListService.LoadTasksAsync();  // Load tasks asynchronously
            return View("Index", _taskListService.tasks);  // Pass the tasks to the Index view
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(Models.Task task)
        {
            await _taskListService.AddTaskAsync(task);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTask(Models.Task task)
        {
            await _taskListService.UpdateTaskAsync(task);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTask(int taskId)
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
}

using Microsoft.AspNetCore.Mvc;
using testy_lab5;

[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{
    private readonly TaskManager _taskManager;

    public TaskController(TaskManager taskManager)
    {
        _taskManager = taskManager;
    }

    [HttpPost]
    public IActionResult CreateTask(testy_lab5.Task task)
    {
        _taskManager.AddTask(task);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAllTasks()
    {
        var tasks = _taskManager.GetTasks();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public IActionResult GetTaskById(int id)
    {
        var task = _taskManager.GetTaskById(id);
        if (task != null)
        {
            return Ok(task);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, testy_lab5.Task updatedTask)
    {
        var result = _taskManager.UpdateTask(id, updatedTask);
        if (result)
        {
            return Ok();
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var result = _taskManager.DeleteTask(id);
        if (result)
        {
            return Ok();
        }
        return NotFound();
    }
}

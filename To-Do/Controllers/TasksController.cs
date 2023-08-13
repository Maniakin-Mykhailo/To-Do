using Microsoft.AspNetCore.Mvc;
using To_Do.Data;
using To_Do.Models;
using System.Linq;

public class TasksController : Controller
{
    private readonly ApplicationDbContext _context;

    public TasksController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var tasks = _context.Tasks.ToList();
        return View(tasks);
    }


    /// <summary>
    /// Add new task
    /// </summary>
    /// <returns>return RedirectToAction("Index");</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(TaskItem task)
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Delete chosen task
    /// </summary>
    /// <returns>return RedirectToAction("Index");</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    /// <summary>
    /// Delete all
    /// </summary>
    /// <returns>return RedirectToAction("Index");</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteAll()
    {
        var completedTasks = _context.Tasks.ToList();
        foreach (var task in completedTasks)
        {
            _context.Tasks.Remove(task);
        }
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}

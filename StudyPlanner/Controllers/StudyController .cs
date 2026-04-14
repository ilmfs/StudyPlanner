using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyPlanner.Data;
using StudyPlanner.Models;

namespace StudyPlanner.Controllers
{
    public class StudyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudyController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Upcoming()
        {
            var tasks = await _context.StudyTasks
                .OrderBy(t => t.Subject)
                .ThenBy(t => t.Deadline)
                .ToListAsync();

            return View(tasks);
        }

        public IActionResult Create()
        {
            return View(new StudyTaskViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudyTaskViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var task = new StudyTask
            {
                Subject = model.Subject,
                Title = model.Title,
                Deadline = model.Deadline,
                Priority = model.Priority,
                IsDone = false
            };

            _context.StudyTasks.Add(task);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Задача успешно добавлена!";
            return RedirectToAction("Upcoming");
        }

        public async Task<IActionResult> Done(int id)
        {
            var task = await _context.StudyTasks.FindAsync(id);
            if (task == null) return NotFound();

            task.IsDone = true;
            await _context.SaveChangesAsync();

            return RedirectToAction("Upcoming");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.StudyTasks.FindAsync(id);
            if (task == null) return NotFound();

            _context.StudyTasks.Remove(task);
            await _context.SaveChangesAsync();

            return RedirectToAction("Upcoming");
        }
    }
}

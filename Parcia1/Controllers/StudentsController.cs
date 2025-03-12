using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcia1.Db;
using Parcia1.Models;

namespace Parcia1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _dbcon;

        public StudentsController(ApplicationDbContext appDb)
        {
            _dbcon = appDb;
        }

        // Mostrar listado de estudiantes
        public IActionResult Index()
        {
            var students = _dbcon.Students
                                  .OrderBy(s => s.Name)
                                  .ToList();
            return View(students);
        }

        // Crear o editar un estudiante
        [HttpGet]
        public IActionResult UpSert(int id)
        {
            var student = id == 0 ? new Students() : _dbcon.Students.Find(id) ?? new Students();
            return View(student);
        }

        [HttpPost]
        public IActionResult UpSert(Students model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.IdStudent == 0)
                _dbcon.Students.Add(model);
            else
                _dbcon.Students.Update(model);

            _dbcon.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(Students student)
        {

            if (ModelState.IsValid)
            {
                _dbcon.Add(student);
                _dbcon.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }


        // Confirmación de eliminación de un estudiante
        public IActionResult Delete(int id)
        {
            var student = _dbcon.Students.Find(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _dbcon.Students.Find(id);
            if (student != null)
            {
                _dbcon.Students.Remove(student);
                _dbcon.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

}
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortelWeb.Data;
using StudentPortelWeb.Models;
using StudentPortelWeb.Models.Entities;

namespace StudentPortelWeb.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDBContext dBContext;

        public StudentsController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Place=viewModel.Place,
                Subscribed = viewModel.Subscribed,
            };
            await dBContext.Students.AddAsync(student);
            await dBContext.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List()

        {
            var students = await dBContext.Students.ToListAsync();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)

        {
            var student = await dBContext.Students.FindAsync(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dBContext.Students.FindAsync(viewModel.sid);
            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Place = viewModel.Place;
                student.Subscribed = viewModel.Subscribed;

                await dBContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dBContext.Students.FindAsync(viewModel.sid);
            if (student is not null)
            {
                dBContext.Students.Remove(student);
                await dBContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");

        }
    }
}

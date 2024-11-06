using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;
using System.Linq;

[Authorize]
public class HomeController : Controller
{
    private readonly SchoolContext _context;

    public HomeController(SchoolContext context)
    {
        _context = context;
        SeedCategories(); 
    }

    private void SeedCategories()
    {
        if (!_context.Categories.Any())
        {
            _context.Categories.AddRange(
                new Category { Name = "Mathematics" },
                new Category { Name = "Science" },
                new Category { Name = "Literature" },
                new Category { Name = "History" },
                new Category { Name = "Art" }
            );
            _context.SaveChanges();
        }
    }

    public IActionResult Index()
    {
        var students = _context.Students.Include(s => s.Category).ToList();
        return View(students);
    }

    public IActionResult AddStudent()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View();
    }

    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View(student);
    }

    public IActionResult DeleteStudent(int id)
    {
        var student = _context.Students.Find(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    public IActionResult ManageCategories()
    {
        var categories = _context.Categories.ToList();
        return View(categories);
    }

    public IActionResult AddCategory()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("ManageCategories");
        }
        return View(category);
    }
    [HttpGet]
    public IActionResult Search(string searchTerm)
    {
        var students = _context.Students
            .Include(s => s.Category)
            .Where(s => s.Name.Contains(searchTerm) || s.Email.Contains(searchTerm))
            .ToList();

        return View(students);
    }

}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP4.Data;
using TP4.Models;

namespace TP4.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        //get all courses
        public ActionResult Index()
        {
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            //Debug.WriteLine("Hello");
            StudentRepository studentRepository = new StudentRepository(universityContext);
           // Debug.WriteLine("Hello2");
           // Debug.WriteLine(studentRepository);
           

            return View(studentRepository.GetCourses());
        }

        //get students of specific course
        public ActionResult GetStudentsByCourse(string id)
        {
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            StudentRepository studentRepository = new StudentRepository(universityContext);
            IEnumerable<Student> stud = (IEnumerable<Student>)studentRepository.Find(v => v.course.ToLower() == id.ToLower());         
            if (stud.Count() != 0) ViewBag.Id = stud.First().course;
            return View(stud);
        }
    }
}
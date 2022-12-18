using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TP4.Models;

namespace TP4.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        static private UniversityContext universityContextInstance = null;
        static public int count = 0;
        private UniversityContext(DbContextOptions o) : base(o)
        {

            count++;
            Debug.WriteLine("instance :", count);
        }

        static public UniversityContext Instantiate_UniversityContext()
        {
            if (universityContextInstance == null)
            {

                var optionBuilder = new DbContextOptionsBuilder<UniversityContext>();
                Debug.WriteLine("1 ");
                optionBuilder.UseSqlite(@"Data Source=C:\Users\Salma\Downloads\db.db;");
                Debug.WriteLine("2");
                universityContextInstance = new UniversityContext(optionBuilder.Options);
                Debug.WriteLine("3");
                return universityContextInstance;
            }
            else
            {
                return universityContextInstance;
            }
        }
    }
}
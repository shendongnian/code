    using Microsoft.EntityFrameworkCore;
    namespace Student.Web.StudentContext
    {
        // Move it here
        using Student.Web.Models;
        public class StudentDbContext : DbContext
        {
            public StudentDbContext()
            {
            }
            public DbSet<Student> Students { get; set; }
        }
    }
    namespace Student.Web.Models
    {
        public class Student
        {
            public int StudentId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }

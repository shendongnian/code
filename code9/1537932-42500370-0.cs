    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student {Name = "Miguel", Grades = 90},
                new Student {Name = "Maddie", Grades = 70},
                new Student {Name = "John", Grades = 65},
                new Student {Name = "Isabella", Grades = 80},
                new Student {Name = "Raul", Grades = 75}
            };
            Console.WriteLine("Please enter your name: "); // Asking the user to type his/her name
            string studentName = Console.ReadLine(); //
            var student = students.FirstOrDefault(std => std.Name == studentName);
            if (student != null)
            {
                Console.WriteLine(studentName + " your score was " + student.Grades);
            }
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int Grades { get; set; }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication27
    {
        class Program
        {
     
            static void Main(string[] args)
            {
                IEnumerable<Student> students = new List<Student> {
                    new Student() {Id = 1, Name = "John", Age = 13},
                    new Student() {Id = 2, Name = "Mary", Age = 12},
                    new Student() {Id = 3, Name = "Anne", Age = 14}
                };
                IEnumerable<StudentScore> studentScores = new List<StudentScore> {
                    new StudentScore() {StudentId = 1, Subject = "Maths", Points = 54},
                    new StudentScore() {StudentId = 1, Subject = "Maths", Points = 32},
                    new StudentScore() {StudentId = 1, Subject = "English", Points = 55},
                    new StudentScore() {StudentId = 1, Subject = "English", Points = 54},
                    new StudentScore() {StudentId = 2, Subject = "Maths", Points = 44},
                    new StudentScore() {StudentId = 2, Subject = "Maths", Points = 37},
                    new StudentScore() {StudentId = 2, Subject = "English", Points = 59},
                    new StudentScore() {StudentId = 2, Subject = "English", Points = 64},
                    new StudentScore() {StudentId = 3, Subject = "Maths", Points = 53},
                    new StudentScore() {StudentId = 3, Subject = "Maths", Points = 72},
                    new StudentScore() {StudentId = 3, Subject = "English", Points = 54},
                    new StudentScore() {StudentId = 3, Subject = "English", Points = 59},
                };
                var groups = (from student in students
                              join studentScore in studentScores on student.Id equals studentScore.StudentId into st
                              select new { name = student.Name, scores = st })
                             .Select(x => x.scores.GroupBy(y => y.Subject).Select(z => new { name = x.name, subject = z.Key, totalPoints = z.Select(a => a.Points).Sum() }).ToList()).ToList();
                foreach(var group in groups)
                {
                    foreach(var subject in group)
                    {
                        Console.WriteLine("Student Name : '{0}', Subject : '{1}', Total Score : '{2}'", subject.name, subject.subject, subject.totalPoints);
                    }
                }
            }
        }
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public class StudentScore
        {
            public int StudentId { get; set; }
            public string Subject { get; set; }
            public int Points { get; set; }
        }
    }

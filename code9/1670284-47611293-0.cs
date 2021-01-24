        class Program
        {
            static void Main(string[] args)
            {
                List<School_Class> classes = new List<School_Class>();
                List<Student> students = new List<Student>();
                List<School_Grade> grades = new List<School_Grade>();
                List<Teacher> teachers = new List<Teacher>();
                List<User> users = new List<User>();
                var query = (from c in classes
                             join s in students on c.ClassID equals s.ClassID
                             join g in grades on s.StudentID equals g.StudentID
                             join t in teachers on s.StudentID equals t.TeacherID
                             join u in users on s.UserID equals u.UserID
                             select new { c = c, s = s, g = g, t = t, u = u })
                    .Where(x => x.t.Subject == "Mathematics")
                    .GroupBy(x => new { student = x.s.StudentID, _class = x.c.ClassID, firstname = x.u.FirstName, surname = x.u.SurName })
                    .OrderByDescending(x => x.FirstOrDefault().g.grades.Average())
                    .Select(x => new { firstname = x.Key.firstname, surname = x.Key.surname, sid = x.Key.student, cid = x.Key._class, avg = x.FirstOrDefault().g.grades.Average() })
                    .Take(3).ToList();
            }
        }
        public class School_Class
        {
            public int ClassID { get; set; }
        }
        public class Student
        {
            public int ClassID { get; set; }
            public int StudentID { get; set; }
            public int UserID { get; set; }
        }
        public class School_Grade
        {
            public int StudentID { get; set; }
            public int TeacherID { get; set; }
            public List<int> grades { get; set; }
        }
        public class Teacher
        {
            public int TeacherID { get; set; }
            public string Subject { get; set; }
        }
        public class User
        {
            public string FirstName { get; set; }
            public string SurName { get; set; }
            public int UserID { get; set; }
        }

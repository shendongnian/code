    class Program {
        static void Main(string[] args) {
            using (var ctx = new SchoolContext()) {
                Student stud = new Student() { StudentName = "New Student" };  
                ctx.Students.Add(stud);
                Standard stan = new Standard { StandardId = 524 };
                stud.StantardId = stan.StandardId;
                ctx.Standards.Add(stan);
                ctx.SaveChanges(); } } }

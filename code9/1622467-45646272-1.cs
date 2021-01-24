    static void Main(string[] args)
        {
            var classRoom = ClassRoom.CreateDefault();
            foreach (var student in classRoom.Students)
            {
                Console.WriteLine(student.Age);
            }
            foreach (var teacher in classRoom.Teachers)
            {
                Console.WriteLine(teacher.Age);
            }
        }

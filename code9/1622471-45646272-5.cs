    static void Main(string[] args)
        {
            var classRoom = Create.ClassRoom();
            Console.WriteLine("Students: ");
            foreach (var student in classRoom.Students)
            {
                Console.WriteLine("Name: {0}; Age: {1}", student.Name, student.Age);
            }
            Console.WriteLine("Teachers: ");
            foreach (var teacher in classRoom.Teachers)
            {
                Console.WriteLine("Name: {0}; Subject: {1}", teacher.Name, teacher.Subject);
            }
        }

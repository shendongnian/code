    class Program
    {
        static void Main(string[] args)
        {
            CType.MyClassBuilder MCB = new CType.MyClassBuilder("Student");
            dynamic obj1 = MCB.CreateObject(new string[3] { "ID", "Name", "Address" }, new Type[3] { typeof(int), typeof(string), typeof(string) });
            Type studentType = obj1.GetType();
            var listOfStudents = CreateList(obj1);
            for (int i = 0; i < 10; i++)
            {
                var newObj = Activator.CreateInstance(obj1.GetType());
                studentType.GetProperty("ID").SetValue(newObj, i);
                newObj.Name = "Name" + i;
                listOfStudents.Add(newObj);
            }
            Console.WriteLine(listOfStudents.GetType().FullName);
            foreach (var student in listOfStudents)
                Console.WriteLine(student.ID + " "+ student.Name);
            
            Console.ReadLine();
        }
        public static List<T> CreateList<T>(T obj)
        {
            return new List<T>();
        }
    }

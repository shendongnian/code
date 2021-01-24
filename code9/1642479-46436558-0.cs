    class Program
        {
            static void Main(string[] args)
            {
    
                List<course> Courses = new List<course>();
                Courses.Add(new course() { name = "CA", courseID = 1 });
                Courses.Add(new course() { name = "CB", courseID = 2 });
                Courses.Add(new course() { name = "CC", courseID = 3 });
    
                string column_name = "name";
                string column_value = "C";
                string where = string.Format("{0}.Contains(@0)", column_name); 
                var result = Courses.Where(where, column_value).Select("new(name,courseID, (name + courseID.ToString()) as y)").Take(50);   
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
        }
        public class course
        {
            public string name { get; set; }
            public int courseID { get; set; }
        }

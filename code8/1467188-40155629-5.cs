    public class User
    {
        public int userId { get; set; }
        public string name { get; set; }
    }
    
    public class Programm
    {
        static void Main()
        {
            var list = new List<User>();
    
            list.Add(new User
            {
                userId = 1,
                name = "name 1",
            });
    
            list.Add(new User
            {
                userId = 2,
                name = "name 2",
            });
    
            var data = list.Select(u => u.GetType()
                            .GetProperties()
                            .Select(p => p.GetValue(u, null)));
            Console.WriteLine(new JavaScriptSerializer().Serialize(new
            {
                data = data
            }));
        }
    }

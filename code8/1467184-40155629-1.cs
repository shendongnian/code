    public class User
    {
        public int userId { get; set; }
        public string name { get; set; }
        public List<string> GetPropertyValues()
        {
            return this.GetType()
                        .GetProperties()
                        .Select(p =>
                        {
                            object value = p.GetValue(this, null);
                            return value == null ? null : value.ToString();
                        }).ToList();
        }
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
                            .Select(p =>
                            {
                                object value = p.GetValue(u, null);
                                return value == null ? null : value.ToString();
                            }).ToList());
            Console.WriteLine(new JavaScriptSerializer().Serialize(new
            {
                data = data
            }));
        }
    }

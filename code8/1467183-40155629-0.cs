    public class User 
    {
        public int userId;
        public string name;
    }
    
    class Program
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
    		var result = new {
    			data = list.ToArray()
    		};
            Console.WriteLine(new JavaScriptSerializer().Serialize(result));
        }
    }

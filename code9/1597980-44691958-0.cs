        public class MyClass
        {
            public string Username { get; set; }
            public string Password { get; set; }
    
            public string GetJson()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
        public class MyInheritedClass : MyClass
        {
            public string Email { get; set; }
        }
        public static class MyClassExtension
        {
            public static MyInheritedClass ToMyInheritedClass(this MyClass obj, string email)
            {
                // You could use some mapper for identical properties. . . 
                return new MyInheritedClass()
                {
                    Email = email,
                    Password = obj.Password,
                    Username = obj.Password
                };
            }
        }

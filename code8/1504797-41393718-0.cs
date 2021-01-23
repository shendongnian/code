    public class MyUser
    {
        public string Id { get; set; }
        public bool Status { get; set; }
        public static MyUser GetUser(string param1, string param2)
        { 
           var user=new MyUser();
          //make db call based on param1 and param2 and pupulate MyUser object
          return user;
        }    
    }

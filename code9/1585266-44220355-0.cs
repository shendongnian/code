    public class TodoUserService {
        public IEnumerable<TodoUser> GetAllTodoUsers() {
            Console.WriteLine ("Getting todos...");
            // ...
        }
    }
    
    public class TodoUserController : TableController<TodoUser> {
        public IEnumerable<TodoUser> GetAllTodoUsers() {
            TodoUserService todoUserService = new TodoUserService();
            return todoUserService.GetAllTodoUsers();
        }
    }
    
    
    public class FacebookController : ApiController {
        public FacebookStuff GetFacebookStuff() {
            TodoUserService todoUserService = new TodoUserService();
            var users = todoUserService.GetAllTodoUsers();
            // ... other Facebook stuff		
        }
    }
    

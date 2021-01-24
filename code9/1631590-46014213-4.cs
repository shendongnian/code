    public class TodoRepository : ITodoRepository {
        private readonly ILogger logger; 
  
        public ChildClass(ILogger<TodoRepository> logger) { 
            this.logger = logger;   
        }
      
        //...
    }

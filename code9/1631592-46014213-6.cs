    public class TodoRepository : ITodoRepository {
        private readonly ILogger logger; 
  
        public TodoRepository(ILogger<TodoRepository> logger) { 
            this.logger = logger;   
        }
      
        //...
    }

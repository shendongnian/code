    namespace TodoApi.Controllers
    {
        [Route("api/[controller]")]
        public class TodoController : Controller
        {
            public TodoController(ITodoRepository todoItems)
            {
                TodoItems = todoItems;
            }
            public ITodoRepository TodoItems { get; set; }
        }
    }

            [Route("api")]
          public class TodoController : Controller 
              [HttpGet("todo/{id}", Name = "GetTodo")]//api/todo/43
          public IActionResult GetById(string id)
          [HttpGet("todogroup/{groupdId:int}/todo/{id}", Name = "GetGroupTodo")]//api/todogroup/100/todo/43
          public IActionResult GetById(int groupId, string id)

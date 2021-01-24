                [Produces("application/json")]
                [Route("api/TodoController")]
                public class TodoControllerController : Controller
                {
                    private readonly TodoContext _context
                    public void Get()
                    {
                        _context = context;
                        if (_context.TodoItems.Count() == 0)
                        {
                            string allText = System.IO.File.ReadAllText(@"C:\Users\Alex\Desktop\Prog\A.json");
                            object jsonObject = JsonConvert.DeserializeObject(allText);
                            int x = jsonObject.
                            _context.TodoItems.Add(new TodoItems { Id = '1', Name = "Item1", IsComplete = false, });
                            _context.SaveChanges();
                        }
                    }
                }

    [Produces("application/json")]
    [Route("api/ToDo")]
    public class ToDoController : Controller
    {
        private TodoContext _context;
        public TodoController(TodoContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("Upload")]
        public HttpResponseMessage UploadData()
        {
            try
            {
                if (_context.TodoItems.Count() == 0)
                {
                    string allText = System.IO.File.ReadAllText(@"C:\Users\Alex\Desktop\Prog\A.json");
                    object jsonObject = JsonConvert.DeserializeObject(allText);
                    int x = jsonObject.
                    _context.TodoItems.Add(new TodoItems { Id = '1', Name = "Item1", IsComplete = false, });
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }

    public class TestViewModel
    {
        public string des { get; set; }
    }
    
    public class CommentController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Test(TestViewModel testViewModel)
        {
            return Ok(testViewModel.des);
        }
    }

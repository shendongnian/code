    [Route("api/[controller]")]
    public class MyController: Controller{
        [HttpPost]  
        public string Post([FromBody] Data m)
        {
            PostingToCL post = new PostingToCL();
            string postReturn = post.Post();
            return string.Format(postReturn);
        }
    }

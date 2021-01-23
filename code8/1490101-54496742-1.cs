        [Route("blogs/api/v1")]
    public class BlogController : ControllerBase
    {
        IBloggingContextFactory _bloggingContextFactory;
        public BlogController(IBloggingContextFactory bloggingContextFactory)
        {
            _bloggingContextFactory = bloggingContextFactory;
        }
        [HttpGet("blog/{id}")]
        public async Task<Blog> Get(int id)
        {
            //validation goes here 
            Blog blog = null;
            // Instantiage context only if needed and dispose immediately
            using (IBloggingContext context = _bloggingContextFactory.CreateContext())
            {
                blog = await context.Blogs.FindAsync(id);
            }
            //Do further processing without need of context.
            return blog;
        }
    }

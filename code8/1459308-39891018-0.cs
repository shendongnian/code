    [Route("api/[controller]")]
    public abstract class RestApiController<T> : Controller
    {
        protected abstract Func<int, Task<T>> Get { get; }
        protected abstract Func<Task<IEnumerable<T>>> List { get; }
    
        [HttpGet()]
        public virtual async Task<IEnumerable<T>> OnList()
        {
            if (this.List == null)
            {
                this.NotFound();
            }
    
            return await this.List.Invoke();
        }
    
        [HttpGet("{id:int}")]
        public virtual async Task<T> OnGet(int id)
        {
            if (this.Get == null)
            {
                this.NotFound();
            }
    
            return await this.Get.Invoke(id);
        }
    }
    public class ArticleSummariesController : RestApiController<ArticleExtension>
    {
        private readonly ArticleManager articleManager;
    
        protected override Func<int, Task<ArticleExtension>> Get => null;
        protected override Func<Task<IEnumerable<ArticleExtension>>> List => this.ListAll;
    
        public ArticleSummariesController(ArticleManager articleManager)
        {
            this.articleManager = articleManager;
        }
    
        private async Task<IEnumerable<ArticleExtension>> ListAll()
        {
            return await this.articleManager.GetAllAsync();
        }
    
    }

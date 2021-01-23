    [Route("api/[controller]")]
    public abstract class RestApiController<T> : Controller
    {
        protected abstract Func<int, Task<T>> Get { get; }
        protected abstract Func<Task<IEnumerable<T>>> List { get; }
    
        [HttpGet, Route("list")]
        protected virtual async Task<IEnumerable<T>> OnList()
        {
            if (this.List == null)
            {
                this.NotFound();
            }
    
            return await this.List.Invoke();
        }
    
        [HttpGet, Route("get/{id:int}")]
        protected virtual async Task<T> OnGet(int id)
        {
            if (this.Get == null)
            {
                this.NotFound();
            }
    
            return await this.Get.Invoke(id);
        }
    }

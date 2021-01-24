    public class ReadOnlyBaseController<TEntity, TEntityResource> : Controller {
        protected readonly IMapper mapper;
        protected readonly IBaseUnitOfWork unitOfWork;
        protected readonly IBaseRepository<TEntity> repository;
        public ReadOnlyBaseController(
            IBaseRepository<TEntity> repository, IBaseUnitOfWork unitOfWork, IMapper mapper) {
            //...
        }
    
        [HttpGet]
        public virtual async Task<IActionResult> Get() {
            //..
        }
    
        [HttpGet("Id")]
        public virtual IActionResult GeSingle(int Id) { 
            //...
        }
    }

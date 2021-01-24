    public class ReadOnlyBaseController<TEntity, TEntityResource> : Controller {
        private readonly IMapper mapper;
        private readonly IBaseUnitOfWork unitOfWork;
        private readonly IBaseRepository<TEntity> repository;
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

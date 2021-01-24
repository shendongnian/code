    [Authorize]
    public class ReadOnlyOAuthController<TEntity, TEntityResource> : ReadOnlyBaseController<TEntity, TEntityResource> {
        public ReadOnlyOAuthController(
            IBaseRepository<TEntity> repository, IBaseUnitOfWork unitOfWork, IMapper mapper) 
                : base(repository, unitOfWork, mapper) {
        }
        [AllowAnonymous]
        [HttpGet("someaction")]
        public IAction SomeOtherAction() {
            //...
        }
    }

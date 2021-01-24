    public class BaseController<T> : ApiController where T : Entity<int>
    {
        ...
        public virtual IEnumerable<T> GetAllEntities()
        {
            return _service.GetAll();
        }
    }
    
    public class ArbitrosController : BaseController<Arbitro>
    {
        ...
        [HasPermission("get")]//filter atribute
        public override IEnumerable<Arbitro> GetAllEntities()
        {
           return base.GetAllEntities();
        }
    }

    public class ListItemsController<T> : ApiControllerBase
    {
        //Properties/Fields should be protected to can be accessed from InstanceController.
        protected readonly IListItemsService<T> _service;
        // I think listItemTypeId is not necessary, if generic-type T is used?
        public ListItemsController()
        {
            _service = ListItemsFactory<T>.InitializeService();
        }
    
        [HttpGet] // No need for RouteAttribute, because it will be in InstanceController.
        public IEnumerable<T> GetAll()
        {
            return _service.GetAll();
        }
    
        [HttpGet]
        [Route("test")] // This can rest here, because you want to use it.
        public IHttpActionResult Test()
        {
            return Ok();
        }
    
    
    
    }

    public class BaseController<T> : ODataController
    {
        AccordNewModel _db = new AccordNewModel();
        
        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(_db.Set<T>().AsQueryable());
        }
        
        [HttpPost]
        public IHttpActionResult Post(T posted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var added = _db.Set<T>().Add(posted);
            _db.SaveChanges();
            return Created(added);
        }
    
        //Etc... Write generic controller methods using Db.Set<T>()

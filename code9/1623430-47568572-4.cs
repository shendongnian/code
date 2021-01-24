    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        public UserController(UserContext context)
        {
            _context = context;
            if(_context.Users.Count() == 0 )
            {
                _context.Users.Add(new User { Id = 0, Username = "Abdul Hameed Abdul Sattar", Country = "Indian", Password = "123456" });
                _context.SaveChanges();
            }
        }
        [HttpGet("[action]")]
        public IEnumerable<User> GetList()
        {
            return _context.Users.ToList();
        }
        [HttpGet("[action]/{id}", Name = "GetUser")]
        public IActionResult GetById(long id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }
        [HttpPost("[action]")]
        public IActionResult Create([FromBody] User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }
        [HttpPut("[action]/{id}")]
        public IActionResult Update(long id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var userIdentified = _context.Users.FirstOrDefault(u => u.Id == id);
            if (userIdentified == null)
            {
                return NotFound();
            }
            userIdentified.Country = user.Country;
            userIdentified.Username = user.Username;
            _context.Users.Update(userIdentified);
            _context.SaveChanges();
            return new NoContentResult();
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(long id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }

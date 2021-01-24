     public class CommonController : Controller
        {
    
            private readonly ArtCoreDbContext _context;
    
            public CommonController(ArtCoreDbContext context)
            {
                _context = context;
            }
    
            [HttpGet]
            public IEnumerable<IdState> GetState()
            {
    
                return _context.IdState;
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetState([FromRoute] int id)
            {
                var  L2EQuery = await (from i in _context.IdState
                                        where i.test.equals("abc")
                                          select new { Id = i.StaeId, text= i.text }).ToListAsync();
    
                return Ok(L2EQuery);
            }
        }

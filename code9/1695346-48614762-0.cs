	[Produces("application/json")]
	// [Route] attribute removed
	public class DocumentsController : Controller
	{
		private readonly DatabaseContext _context;
		public DocumentsController(DatabaseContext context)
		{
			_context = context;
		}
		// GET: api/Documents
		[HttpGet("documents", Order = 2)]
		public IActionResult GetDocuments()
		{
			// returns a JSON list of documents, works fine
		}
		// GET: api/Documents/5
		[HttpGet("documents/{id}", Order = 1)]
		public async Task<IActionResult> GetDocument([FromRoute] int id)
		{
			//returns the specified document, is never even called
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var document = await _context.Documents.SingleOrDefaultAsync(m => m.Id == id);
			if (document == null)
			{
				return NotFound();
			}
			return Ok(document);
		}
	}

    [Route("api/authors")]
    public class AuthorsController : BaseController<AuthorsController>
    {
        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet("LogMessage")]
        public IActionResult LogMessage(string message)
        {
            Logger.LogInformation(message);
            return Ok($"The following message has been logged: '{message}'");
        }

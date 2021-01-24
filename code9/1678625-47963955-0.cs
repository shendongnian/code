    public class PagesController : AsyncController, IPagesController
    {
        private readonly IPagesService _pagesService;
    
        public PagesController(IPagesService pagesService)
        {
            _pagesService = pagesService;
        }
    
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> IndexAsync()
        {
            var viewModel = await _pagesService.GetAllAsync();
            return PartialView("MenuPartial", viewModel);
        }
    }

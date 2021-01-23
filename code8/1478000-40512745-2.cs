    public class PivController : Controller
    {
        private readonly PivHelper _helper;
        public PivController (PivHelper pivHelper)
        {
            _helper = pivHelper;
        }
        public async Task<IActionResult> GetPiv()
        {
            var piv = await _helper.PivTask;
            // Act on the piv, or simply return it...
        }
    }

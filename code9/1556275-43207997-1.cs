    public class HomeController : Controller
    {
        public async Task IndexAsync(CancellationToken cancellationToken)
        {
            var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
                AuthorizeAsync(cancellationToken);
            if (result.Credential != null)
            {
                var service = new DriveService(new BaseClientService.Initializer
                    {
                        HttpClientInitializer = result.Credential,
                        ApplicationName = "ASP.NET MVC Sample"
                    });
                // YOUR CODE SHOULD BE HERE..
                // SAMPLE CODE:
                var list = await service.Files.List().ExecuteAsync();
                ViewBag.Message = "FILE COUNT IS: " + list.Items.Count();
                return View();
            }
            else
            {
                return new RedirectResult(result.RedirectUri);
            }
        }
    }

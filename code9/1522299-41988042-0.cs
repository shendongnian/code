    public class BannerViewComponent : ViewComponent
    {
      public async Task<IViewComponentResult> InvokeAsync(string param1, int param2)
      {
        string model = "<strong>some custom html</strong>";
        return View("Index", model);
      }
    }

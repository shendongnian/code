    [ViewComponent(Name = "Cart")]
    public class CartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
             return View("");
        }
    }

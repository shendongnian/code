    public class ViewModel : RenderModel
    {
        public ViewModel(IPublishedContent content) : base(content) { }
        ...
    }
    public override ActionResult Index(RenderModel model)
    {
        var vm = new ViewModel(model);
        return View("Hires", vm);
    }

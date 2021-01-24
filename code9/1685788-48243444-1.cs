    public class ViewModel : RenderModel
    {
        public ViewModel(IPublishedContent content) : base(content) { }
        
        public List<HireItem> HireItems { get; set; }
    }
    public override ActionResult Index(RenderModel model)
    {
        var vm = new ViewModel(model);
        vm.HireItems = new HireItemsRepo().GetHireItems();
        return View("Hires", vm);
    }

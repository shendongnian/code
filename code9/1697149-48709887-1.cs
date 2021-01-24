    [Export]
    public class ParentViewModel
    {
        [ImportMany] // <- this attribute tells MEF to look for all exports of type ISubViewModel
        public IEnumerable<ISubViewModel> ViewModels { get; set; }
        //... whatever else you need
    }
    

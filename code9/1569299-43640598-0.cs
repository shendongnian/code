    public class LabelViewModel
    {
        [Display(Name = "Employee\nId")]
        public int EmployeeId { get; set; }
        //display for is for iterating over a collection
        public IList<string> Employees { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index54()
        {
            //display for is for iterating over a collection
            LabelViewModel labelViewModel = new LabelViewModel();
            labelViewModel.Employees = new List<string>();
            labelViewModel.Employees.Add("emp1");
            labelViewModel.Employees.Add("emp2");
            return View(labelViewModel);
        }

    public class VoyageViewModel
    {
        public log_voyage log { get; set; }
        public List<log_ligne_voyage> log_ligne_voyage_list { get; set; }
    }
    
    public ActionResult Index(VoyageViewModel voyageViewModel)
    {
        ...
    }

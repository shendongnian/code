      namespace KenCast.ViewComponents
    {
        public class CaseStudiesViewComponent : ViewComponent
        {
            //allows for data access
            private readonly ApplicationDbContext _context;
        public CaseStudiesViewComponent(ApplicationDbContext c)
        {
            _context = c;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            var casestudies = (from cs in _context.CaseStudies.ToList()
                              .OrderByDescending(cs => cs.CaseStudyDate)
                              .ThenBy(cs => cs.CaseStudyTitle)
                               select cs).ToList();
            return Task.FromResult<IViewComponentResult>(View(casestudies));
        }
    }

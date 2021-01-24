    public class SearchTitleViewModel
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        public SearchTitleViewModel()
        {
            Title = new Title()
            {
                NtyId = 1//for testing REMOVE
            };
            Titles = new List<Title>();
        }
        public Title Title { get; set; }
        public List<Title> Titles { get; set; }
 
        public SearchTitleViewModel GetTitlesWithSearchCriteria(SearchTitleViewModel vm)
        {
            var searchtitlevm = new SearchTitleViewModel();
            if (vm.Title.TitleNum != null)
            {
                searchtitlevm.Title = _db.Titles.Find(vm.Title.TitleNum);
                if (searchtitlevm.Title != null && searchtitlevm.Title.NtyId != vm.Title.NtyId)
                {
                    return searchtitlevm;
                }
                searchtitlevm.Titles.Add(searchtitlevm.Title);                
                return searchtitlevm;
            }
            var titssql = "SELECT * FROM Titles WHERE";
            if (vm.Title.Vin != null) { titssql += $" Vin = \'{vm.Title.Vin}\' AND "; }
            if (vm.Title.CustLName != null) { titssql += $" CustLName = \'{vm.Title.CustLName}\' AND "; }
            if (vm.Title.CustFName != null) { titssql += $" CustFName = \'{vm.Title.CustFName}\' AND "; }
            titssql += $" NtyId = \'{vm.Title.NtytyId}\'";
            searchtitlevm.Titles = _db.Titles.SqlQuery(titssql).ToList();
            
            return searchtitlevm;
        }
    }

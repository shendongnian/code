    Paging pg = new Paging();
    private projectEntities db = new projectEntities();
    //ex : Controller name-> news , view_name -> browse
    public ActionResult Index()
        {
            int offset = 1;
            int Page = 1;
            int Take = 20;
            if (Convert.ToInt32(Request.QueryString["Page"]) > 1)
            {
                Page = Convert.ToInt32(Request.QueryString["Page"]);
            }
            int skip = 0;
            if (Page == 1)
                skip = 0;
            else
                skip = ((Page - 1) * Take);
            int total = db.Table_Name.Count();
            var data = db.Table_Name.Skip(skip).Take(Take);
            string paging = pg.Pagination(total, Page, Take, offset, "news", "/browse", "");
            ViewBag.Paging = paging;
            return View(data.ToList());
        }

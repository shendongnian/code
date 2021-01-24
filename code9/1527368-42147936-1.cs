    [HttpGet]
    [Route("api/LandingPage/GetByDate")]
    public JsonResult GetByDate(DateTime startDate, DateTime endDate)
    {
        try
        {
            var startDateParam = new SqlParameter("@startDate", startDate);
            var endDateParam = new SqlParameter("@endDate", endDate);
    
            var confirmData = m_databaseObject.Database.SqlQuery<PageModel>("[dbo].[GetPageData] @startDate,@endDate", startDateParam, endDateParam).ToList();
    
            return new JsonResult() { Data = confirmData , JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        catch (Exception e)
        {
            throw;
        }
    }

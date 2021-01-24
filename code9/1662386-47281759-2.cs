    [HttpPost]
    public IHttpActionResult AddDetailsConfiguration(int quarter, int year, string project)
    {
        //Check here if values in parameter are set and if values are correct
    
        var detailsConfiguration = new DetailsConfiguration
        {
             Quarter = quarter,
             Year = year,
             Project = project
        }
    
        //Insert detailsConfiguration to database
        Return Ok();
    }

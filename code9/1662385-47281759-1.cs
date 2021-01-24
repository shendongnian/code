    [HttpPost]
    public IHttpActionResult AddDetailsConfiguration(DropDownConfiguration parameter)
    {
       //check here if values in parameter are set
    
       var detailsConfiguration = new DetailsConfiguration {
            Quarter = parameter.Quarter,
            Year = parameter.Year,
            Project = parameter.Project
       }
       //Insert detailsConfiguration to database
       Return Ok();
    }
 

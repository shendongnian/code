    @using(Html.BeginForm())
    {
        <div>
             // Your code 
            <div>
                <input type="submit" value="Go" />
            </div>
        </div>
    }
 
    [HttpPost]
    public ActionResult Index(UploadViewModel model)
    {
        //do someting
    }
 

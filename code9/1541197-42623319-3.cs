    [HttpGet]
    [Route("GetList")]
    public ActionResult GetList(string psSelect)
    {
        List<dynamic> loList = new List<dynamic>();
        if (string.IsNullOrEmpty(psSelect))
        {
            loList.Add(new { id = "1", firstname = "Tyler", lastname = "Durden"         });
        }
        else
        {
            loList.Add(new { id = "2", firstname = "Big", lastname = "Lebowski" });
        }
    
        return new MyJsonResult(loList);
    }

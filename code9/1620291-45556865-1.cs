    //Matches action
    //Matches action/page-1
    [Route("action/{page:regex(^page-\d$)?}")]
    public IActionResult Action(string page = "page-1") {
        //... parse page
        // page number = page.Replace("page-", "");
        // then int.Parse() page number
    }

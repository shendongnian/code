    public ActionResult Movie()
    {
        var list = ViewState["MyList"] as List<Movie>;
        if(list == null)
        {
           list = new List<Movie>();
           ViewState["MyList"] = list;
        }
        int id = Convert.ToInt16(Request.Form["inputmovieid"]);
        string name = Request.Form["inputmovietitle"];
        int year = Convert.ToInt16(Request.Form["inputproductionyear"]);
        Movie movieitem = new Movie(id, name, year);
        list.Add(movieitem);
        return View(list);
    }

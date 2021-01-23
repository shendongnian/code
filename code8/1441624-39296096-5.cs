    public ActionResult Confirm(int id)
    {
       var d = db.Data.FirstOrDefault(g=>g.Id==id);
       // Use d as needed   
       // to do : Return something
    }

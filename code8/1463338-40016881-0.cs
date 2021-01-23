    class SampleModel {
      public string Title {get;set;};
    }
    
    public ActionResult AufgabenDetails(int id)
    {
          SampleModel  prjname = new SampleModel { Title = "Album " + id };
          return View(prjname);
    }

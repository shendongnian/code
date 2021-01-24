          public ActionResult Index()
          {
            if (Request.Url.Host.Equals("domain2"))
                return AnotherAction();
          }

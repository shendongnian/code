       [HttpPost]
       public ActionResult Index(Tuple<List<log_voyage>, List<log_ligne_voyage>> voy)
       {
         try
         {
          if (voy.Item1.Count() == 0)
          {
              // followed by your code

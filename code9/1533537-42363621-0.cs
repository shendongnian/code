        public ActionResult GetFiles(HttpPostedFileBase NewsFilePath)
        {
            if (NewsFilePath != null)
            {
                var files = Session["Files"] == null ?
                    new List<HttpPostedFileBase>() :
                    (List<HttpPostedFileBase>)Session["Files"];
                files.Add(NewsFilePath);
                Session["Files"] = files.Distinct();
            }
            return Content("");
        }

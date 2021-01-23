      public ActionResult List(Prop obj)
            {
                obj.Images=Directory.EnumerateFiles(Server.MapPath("~/Content/Files/"))
                    .Select(fn => "~/Content/Files/" + Path.GetFileName(fn));
                var objfile = new DirectoryInfo(Server.MapPath("~/Content/Files/"));
                var file = objfile.GetFiles("*.*");              
                return View(obj);
            }

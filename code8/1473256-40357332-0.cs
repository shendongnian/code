        public ActionResult Details(int? vesselId)
        {
            //
            // Enumerate through the images directory and
            //return the results to the view.
            var filePath = Server.MapPath("~/Content/images/vessels/");
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var model = new VesselImagesViewModel
            {
                VesselImages = Directory.EnumerateFiles(filePath)
                .Select(fn => "~/Content/images/vessels/" + Path.GetFileName(fn))
                .Where(id => Path.GetFileNameWithoutExtension(id) == vesselId.ToString())
            };
            return View(model);
        }

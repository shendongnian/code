        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadMasterCodes(CampaignMasterCodeUploadViewModel model)
        {
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileName(model.File.FileName);
                var path = FileMethods.UploadFile(model.File, Server.MapPath("~/App_Data/Bsa4/"), filename);
                var dt = CampaignMethods.ProcessMasterCodeCsvToDatatable(path, model.CampaignId);
                TempData["SuccessMessage"] = CampaignMethods.ProcessMastercodeSqlBulkCopy(dt);
                return RedirectToAction("Details", new { id = model.CampaignId });                
            }
            TempData["ErrorMessage"] = "Master code upload form error.  Please refresh the page and try again.";
            return RedirectToAction("Details", new { id = model.CampaignId });
        }

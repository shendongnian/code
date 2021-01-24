     public ActionResult PoliciesDownload(int ID)
            {
                if (ID == 0) { return null; }
                PoliciesImageModel resume = new PoliciesImageModel();
                EFDbContext rc = new EFDbContext();
                resume = rc.PoliciesImages.Where(a => a.ID == ID).SingleOrDefault();
                return File(resume.Path, "application/pdf");
            }

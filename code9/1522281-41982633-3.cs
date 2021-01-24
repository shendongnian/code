    public ActionResult PoliciesDownload(int ID)
    {
        if (ID == 0) { return null; }
        using (var context = new DBContext()) {
            PoliciesImages policies = context.PoliciesImages;
            var policy = policies.Where(a => a.ID == ID).SingleOrDefault();
            byte[] fileBytes = File.ReadAllBytes(policies.Path);
            Response.AddHeader("Content-Disposition", "inline; filename=policies.DisplayName + ".pdf");
            return File(fileBytes , "application/pdf");
        }
        return null;
    }

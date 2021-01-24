    public ActionResult PoliciesDownload(int ID)
    {
        if (ID == 0) { return null; }
        PoliciesImageModel policies = new PoliciesImageModel();
        policies = policies.Where(a => a.ID == ID).SingleOrDefault();
        byte[] fileBytes = File.ReadAllBytes(policies.Path);
        Response.AddHeader("Content-Disposition", "inline; filename=policies.DisplayName + ".pdf");
        return File(fileBytes , "application/pdf");
    }

    public FileContentResult PoliciesDownload(int ID)
    {
        if (ID == 0) { return null; }
        PoliciesImageModel policies = new PoliciesImageModel();
        policies = policies.Where(a => a.ID == ID).SingleOrDefault();
        var fileBytes = File.ReadAllBytes(policies.Path);
        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, policies.DisplayName + ".pdf");
    }

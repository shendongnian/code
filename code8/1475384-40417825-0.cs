    public ActionResult DownloadFile(int id) {
        var DB = new DataModel();
        var patient = DB._PATIENT.Where(m => m.ID == id).FirstOrDefault();
        if (patient != null && patient.Result != null && patient.Result.Length > 0) {
            var content = patient.Result; //this is a byte[] of the pdf
            Response.AddHeader("Content-Disposition", "inline; filename=someFile.pdf");
            return File(content, "application/pdf");
        }
        return RedirectToAction("BadPatientFile");
    }

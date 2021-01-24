    public ActionResult UploadFile(HttpPostedFileBase file, string submitButton, string connectionId)
    {
        ProgressHub.NotifyStart(connectionId);
        Thread.Sleep(2000);
        ProgressHub.NotifyProgress(connectionId, 20);
        Thread.Sleep(2000);
        ProgressHub.NotifyProgress(connectionId, 50);
        Thread.Sleep(2000);
        ProgressHub.NotifyProgress(connectionId, 100);
        return Json("Done", JsonRequestBehavior.AllowGet);
    }

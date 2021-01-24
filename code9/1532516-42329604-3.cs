    [HttpPost]
    public ActionResult MailwithAttachment(MSSCOSEC.Models.MailModel objModelMail)
    {
        if (ModelState.IsValid)
        {
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = GetDataTableOrWhatever();
            wb.Worksheets.Add(dt,"WorksheetName");
            wb.SaveAs("WhateverName.xlsx");
           // Your code for attaching the file and emailing it
        }
    }

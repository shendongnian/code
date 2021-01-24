            public ActionResult BankAccountReport(BankAccountsInfoFilter bankAccountsInfoFilter)
            {      
                var bankAccountInfos = service.GetBankAccounts(bankAccountsInfoFilter);
    
                DetailReportExport(bankAccountInfos);
   
                return new EmptyResult();
            }
            [NonAction]
            public void DetailReportExport(List<BankAccountViewModel> bankAccountInfos)
            {
                string html = RenderPartialViewToString("_BankAccountDetailReport", bankAccountInfos);
    
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=BankAccountInfoDetailReport.xls");
                Response.ContentType = "application/excel";
                Response.AddHeader("content-language", "tr-TR");
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
                Response.Write(html);
            }

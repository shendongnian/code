        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("export-to-csv")]
        public FileStreamResult ExportDeposits([FromUri(Name = "")]DepositSearchParamsVM depositSearchParamsVM)
        {
            if (depositSearchParamsVM == null)
            {
                depositSearchParamsVM = new DepositSearchParamsVM();
            }
            var records = _DepositsService.SearchDeposits(depositSearchParamsVM);
            var result = _DepositsService.WriteCsvToMemory(records);
            var memoryStream = new MemoryStream(result);
            Response.ContentType = new MediaTypeHeaderValue("application/octet-stream").ToString();// Content type
            return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "export.csv" };
        }

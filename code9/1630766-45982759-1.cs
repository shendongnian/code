    [HttpPost]
    [Route("Api/ReportApi/SummaryReport")]
    public IHttpActionResult SummaryReport([FromBody]JToken tranData)
    {
        BankTransactionsViewModelResults transactions = tranData.ToObject<BankTransactionsViewModelResults>();
       
        // other processing code
        ....
    }

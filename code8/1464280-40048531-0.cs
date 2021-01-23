    class ProcessAccountViewModel()
    {
       ...
       DateTime TransactionEffectiveDate { get; set; } // you already have this
       string TransactionEffectiveDateAsString // add this
       {
           set
           {
               TransactionEffectiveDate = DateTime.ParseExact(value,
                          "yyyyMMdd", CultureInfo.InvariantCulture);
           }
       }
    }

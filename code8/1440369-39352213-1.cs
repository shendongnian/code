    void Engine_AfterReadRecord(EngineBase engine, FileHelpers.Events.AfterReadEventArgs<UserInfoFromAd> e)
     {
         string allMyErrors = null;
         
         bool isDateValid = IsDateValid(e.Record.EffectiveDate);
         if (!isDateValid)
         {
            allMyErrors += "Date is invalid. ";
         }
         bool isCustomerIdValid = IsCustomerIDValid(e.Record.CustomerID);
         if (!isCustomerIdValid)
         {
            allMyErrors += "CustomerID is invalid. ";
         }
         if (!String.IsNullOrEmpty(allMyErrors))
             throw new Exception(allMyErrors);
     }

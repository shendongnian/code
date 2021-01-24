    void Page_Load(object source, EventArgs e)
    {
         //1. Check that more than 5 minutes happened before last sent
         DateTime lastSent = ...;
         if (DateTime.Now().Substract(lastSent).Minutes < 5)
              return;
         
         //2. Get your invoices and PDF files
         var dataToSent = ...;
         //3. Send your invoices
         foreach(var item in dataToSent) 
         {
              //4. Save sent date every time to avoid resending in case the whole operation takes more than 5 minutes 
              saveSentTime();
              
             //5. Finally send your data
         }
    }

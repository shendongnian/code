          // example date
           DateTime date = new DateTime(2005,4,10);
           List<QueryRow> queryResult = App.StorageRepository.Query("appointments_appointment");
           // serach for all items in collection where Document.GetProperty("startDate") == date
           IEnumerable<QueryRow> results = queryResult.Where(item => Convert.ToDateTime(item.Document.GetProperty("startDate")) == date)
           // loop items
           foreach (QueryRow result in results)
           {
               // do something with the row
           }

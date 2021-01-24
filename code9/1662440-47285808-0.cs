    DataResource.RealtimeResource.GetRequest request = 
    service.Data.Realtime.Get(String.Format("ga:{0}", profileId), "rt:activeUsers");
    RealtimeData feed = request.Execute();
    foreach (List  row in realTimeData.Rows) 
    {
     foreach (string col in row) 
        {
         Console.Write(col + " ");  // writes the value of the column
         }
    Console.Write("\r\n");
    }

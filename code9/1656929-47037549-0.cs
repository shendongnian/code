    void ReadFromClient()
    {
         var sr = client.clientStreamReader;
         string data;
         try
         {
           if ((data = sr.ReadLine()) != null)
           {
              Console.WriteLine(data);
           }
         }
         catch (Exception e)
        {
           Console.WriteLine(e);
        }
    }
    Action act = new Action( () =>  ReadFromClient());

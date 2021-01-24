    void ReadFromClient(Client client)
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
   

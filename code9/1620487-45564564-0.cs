    public class MyDBRepository
    {
      public IEnumerable<MyClient> GetNamesBySuffix(char symbol)
      {
        List<MyClient> myClients = new List<MyClient>();
        using (MyDBEntities m = new MyDBEntities())
        {
          myClients = m.Clients.Where(c => c.name.Trim().EndsWith(symbol+""))
                               .Select(c=>new MyClient {name=c.name})
                               .ToList();           
          return myClients;
        }
      }
    }

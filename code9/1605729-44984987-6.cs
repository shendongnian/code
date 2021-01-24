    public IEnumerable<Client> RetrieveClients(string endString)
    {
       using (MyDBEntities myDbEntities = new MyDBEntities()) 
       {
            var clients = from c in myDBEntites.Client
                          where c.name.EndsWith(endString)'
                          select c;
            return clients;
       }
    }

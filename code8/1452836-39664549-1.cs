    public class Clients : List<Client>
    {
        public Clients(IEnumerable<Client> clients) 
            : base(clients){}
        public static explicit operator Clients(IList<Client> list)
        {
              return new Clients(list);
        }
    }

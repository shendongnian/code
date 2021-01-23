    public class Clients : List<Client>
    {
        public Clients(IEnumerable<Client> clients) 
            : base(clients){}
        public static explicit operator Clients(List<Client> list)
        {
              return new Clients(list);
        }
    }

    public class Clients 
    {
        private  List<Client> list;
        public Clients(IEnumerable<Client> clients) 
        { this.list = clients.ToList(); }
        public static explicit operator Clients(List<Client> list)
        {
              return new Clients(list);
        }
    }

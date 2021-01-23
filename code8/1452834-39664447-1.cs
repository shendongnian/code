    public class QueryClients
    {
        private Clients _clients;
        public List<Client> FindClientByRevenue(double minimumRevenue)
        {
            Clients returnValue = (from c in _clients
                                    where c.AnnualRevenue >= minimumRevenue
                                    select c).ToList();
            return returnValue;
        }
    }

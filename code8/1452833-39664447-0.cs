    public class QueryClients
    {
        private List<Client> _clients;
        public List<Client> FindClientByRevenue(double minimumRevenue)
        {
            List<Client> returnValue = (from c in _clients
                                    where c.AnnualRevenue >= minimumRevenue
                                    select c).ToList();
            return returnValue;
        }
    }

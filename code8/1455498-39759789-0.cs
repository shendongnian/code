    public interface IPerson
    {
        string Name { get; }
        int Id { get; }
    }
    public interface ISalesSubject : IPerson
    {
        IDictionary<int, IOrder> Orders { get; }
    }
    public abstract class SalesSubject: ISalesSubject
    {
        protected SalesSubject(string name, int id)
        {
            this.Name = name;
            this.Id = id;
            this.Orders = new Dictionary<int, IOrder>();
        }
        protected SalesSubject(string name, int id, IDictionary<int, IOrder> orders)
        {
            this.Name = name;
            this.Id = id;
            this.Orders = orders;
        }
        public string Name { get; protected set; }
        public int Id { get; protected set; }
        public IDictionary<int, IOrder> Orders { get; protected set; }
        public virtual void AddOrder(int itemId, IOrder order)
        {
            if (!this.Orders.ContainsKey(itemId))
            {
                this.Orders.Add(itemId, order);
            }
        }
        public virtual void RemoveOrder(int itemId, IOrder order)
        {
            this.Orders.Remove(itemId, order);
        }
    }
    public class Client : SalesSubject
    {
        
        public Client(string name, int id)
            : base(name, id)
        {
            this.Orders = new Dictionary<int, IOrder>();
        }
        public Client(string name, int id, IDictionary<int, IOrder> orders)
            : base(name, id, orders)
        {
            this.Orders = orders;
        }
    }
    public class DeliveryReceptionist : SalesSubject
    {
        public DeliveryReceptionist(string name, int id)
            : base(name, id)
        {
            this.Clients = new Dictionary<int, Client>();
        }
        public DeliveryReceptionist(string name, int id, IDictionary<int, IOrder> orders)
            : base(name, id, orders)
        {
            this.Clients = new Dictionary<int, Client>();
        }
        public DeliveryReceptionist(string name, int id, IDictionary<int, IOrder> orders, IDictionary<int, Client> clients)
           : base(name, id, orders)
        {
            this.Clients = clients;
        }
        public DeliveryReceptionist(string name, int id, IDictionary<int, Client> clients)
           : base(name, id)
        {
            this.Clients = clients;
        }
        public IDictionary<int, Client> Clients { get; set; }
        public void AddClient(int clientId, Client client)
        {
            if (!this.Clients.ContainsKey(clientId))
            {
                this.Clients.Add(clientId, client);
            }
        }
        public void RemoveClient(int clientId, Client client)
        {
            this.Clients.Remove(clientId, client);
        }
    }
    public interface IOrder
    {
        int ItemID { get; set; }
        double Price { get; set; }
        double Number { get; set; }
    }
    public class Order : IOrder
    {
        public Order(int itemId, double price, double number)
        {
            this.ItemId = itemId;
            this.Price = price;
            this.Number = number;
        }
        public int ItemId { get; set; }
        public double Price { get; set; }
        public double Number { get; set; }
    }
	
	

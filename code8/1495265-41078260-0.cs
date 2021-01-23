    public class OrderBusiness : IAcceptVisitOrder
    {
        private readonly string _id;
        private int _status;
        public OrderBusiness(string id, int status)
        {
            _id = id;
            _status = status;
        }
        public void ChangeStatus(int newStatus)
        {
            //validation logic....
            _status = newStatus;
        }
        public void Accept(IOrderVisitor visitor)
        {
            if (visitor == null) throw new ArgumentNullException(nameof(visitor));
            visitor.Visit(_id, _status);
        }
    }
    public class Client
    {
        private readonly OrderApplicationService _service;
        //Get from Service locator like ninject, etc
        private readonly IReader<OrderBusiness, string> _reader = new OrderBusinessReader();
        private readonly IOrderVisitor _visitor = new UpdateOrderVisitor();
        public Client()
        {
            _service = new OrderApplicationService(_reader, _visitor);
        }
        public void Run(UpdateOrderCommand command)
        {
            _service.When(command);
        }
    }
    public class UpdateOrderCommand
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public int Status { get; set; }
    }
    public class OrderApplicationService
    {
        private readonly IReader<OrderBusiness, string> _reader;
        private readonly IOrderVisitor _visitor;
        public OrderApplicationService(IReader<OrderBusiness, string> reader, IOrderVisitor visitor)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            if (visitor == null) throw new ArgumentNullException(nameof(visitor));
            _reader = reader;
            _visitor = visitor;
        }
        public void When(UpdateOrderCommand command)
        {
            var order = GetBusinessObject(command.Id);
            order.ChangeStatus(command.Status);
            order.Accept(_visitor);
        }
        private OrderBusiness GetBusinessObject(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return _reader.Read(id);
        }
    }
    public interface IReader<out T, in TK>
    {
        T Read(TK id);
    }
    public interface IAcceptVisitOrder
    {
        void Accept(IOrderVisitor visitor);
    }
    public interface IOrderVisitor
    {
        void Visit(string id, int status);
    }
    public class OrderBusinessReader : IReader<OrderBusiness, string>
    {
        public OrderBusiness Read(string id)
        {
            //Read data from db with EF, ADO.NET, ETC
            var status = 0;
            return new OrderBusiness(id, status); 
        }
    }
    class UpdateOrderVisitor : IOrderVisitor
    {
        public void Visit(string id, int status)
        {
            //Persist to database, etc
        }
    }

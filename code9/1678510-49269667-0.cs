    public interface IProductBacklog
    {
        KeyValuePair<bool, int> TryAddProductBacklogItem(string description);
        bool ExistProductBacklogItem(string description);
        bool ExistProductBacklogItem(int backlogItemId);
        bool TryDeleteProductBacklogItem(int backlogItemId);
    }
    public sealed class AddProductBacklogItemBusinessRule
    {
        private readonly IProductBacklog productBacklog;
        public AddProductBacklogItemBusinessRule(IProductBacklog productBacklog)
        {
            this.productBacklog = productBacklog ?? throw new ArgumentNullException(nameof(productBacklog));
        }
        public int Execute(string productBacklogItemDescription)
        {
            if (productBacklog.ExistProductBacklogItem(productBacklogItemDescription))
                throw new InvalidOperationException("Duplicate");
            KeyValuePair<bool, int> result = productBacklog.TryAddProductBacklogItem(productBacklogItemDescription);
            if (!result.Key)
                throw new InvalidOperationException("Error adding productBacklogItem");
            return result.Value;
        }
    }
    public sealed class DeleteProductBacklogItemBusinessRule
    {
        private readonly IProductBacklog productBacklog;
        public DeleteProductBacklogItemBusinessRule(IProductBacklog productBacklog)
        {
            this.productBacklog = productBacklog ?? throw new ArgumentNullException(nameof(productBacklog));
        }
        public void Execute(int productBacklogItemId)
        {
            if (productBacklog.ExistProductBacklogItem(productBacklogItemId))
                throw new InvalidOperationException("Not exists");
            if(!productBacklog.TryDeleteProductBacklogItem(productBacklogItemId))
                throw new InvalidOperationException("Error deleting productBacklogItem");
        }
    }
    public sealed class SqlProductBacklog : IProductBacklog
    {
        //High performance, not loading unnesesary data
        public bool ExistProductBacklogItem(string description)
        {
            //Sql implementation
            throw new NotImplementedException();
        }
        public bool ExistProductBacklogItem(int backlogItemId)
        {
            //Sql implementation
            throw new NotImplementedException();
        }
        public KeyValuePair<bool, int> TryAddProductBacklogItem(string description)
        {
            //Sql implementation
            throw new NotImplementedException();
        }
        public bool TryDeleteProductBacklogItem(int backlogItemId)
        {
            //Sql implementation
            throw new NotImplementedException();
        }
    }
    public sealed class EntityFrameworkProductBacklog : IProductBacklog
    {
        //Use EF here
        public bool ExistProductBacklogItem(string description)
        {
            //EF implementation
            throw new NotImplementedException();
        }
        public bool ExistProductBacklogItem(int backlogItemId)
        {
            //EF implementation
            throw new NotImplementedException();
        }
        public KeyValuePair<bool, int> TryAddProductBacklogItem(string description)
        {
            //EF implementation
            throw new NotImplementedException();
        }
        public bool TryDeleteProductBacklogItem(int backlogItemId)
        {
            //EF implementation
            throw new NotImplementedException();
        }
    }
    public class ControllerClientCode
    {
        private readonly IProductBacklog productBacklog;
        //Inject from Services, IoC, etc to unit test
        public ControllerClientCode(IProductBacklog productBacklog)
        {
            this.productBacklog = productBacklog;
        }
        public void AddProductBacklogItem(string description)
        {
            var businessRule = new AddProductBacklogItemBusinessRule(productBacklog);
            var generatedId = businessRule.Execute(description);
            //Do something with the generated backlog item id
        }
        public void DeletePRoductBacklogItem(int productBacklogId)
        {
            var businessRule = new DeleteProductBacklogItemBusinessRule(productBacklog);
            businessRule.Execute(productBacklogId);
        }
    }
 

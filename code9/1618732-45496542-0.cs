    /* Your Repository implementation would probably look like this */
	public class GenericRepository<TEntity>
	{
		private readonly DbContext context;
		private readonly RemoveStrategyFactory removeStrategyFactory;
	
		public GenericRepository(DbContext context, RemoveStrategyFactory removeStrategyFactory)
		{
			this.context = context;
			this.removeStrategyFactory = removeStrategyFactory;
		}
	
		public void Remove(Func<TEntity, bool> predicate)
		{
			var entitiesToRemove = context.Set<TEntity>()
				.Where(predicate).ToList();
	
			var removeStrategy = removeStrategyFactory.GetStrategy<TEntity>();
	
			foreach (var entity in entitiesToRemove)
			{
				removeStrategy.BeforeRemove(entity);
				context.Set<TEntity>().Remove(entity);
			}
		}
	}
    /* SAMPLE ENTITIES */
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Order> Orders { get; set; }
	}
	public class Order
	{
		public int Id { get; set; }
		public Customer Customer { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool IsArchived { get; set; }
	}
    /* SAMPLE STRATEGIES and FACTORY */
	public abstract class RemoveStrategy<TEntity>
	{
		public abstract void BeforeRemove(TEntity entity);
	}
	public sealed class DoNothingRemoveStrategy<TEntity> : RemoveStrategy<TEntity>
	{
		public override void BeforeRemove(TEntity entity)
		{
			// Do nothing
		}
	}
	public sealed class CustomerRemoveStrategy : RemoveStrategy<Customer>
	{
		public override void BeforeRemove(Customer customer)
		{
			// Mark all orders as archived
			foreach (var order in customer.Orders)
			{
				order.IsArchived = true;
			}
		}
	}
	public class RemoveStrategyFactory
	{
		private readonly Lazy<Dictionary<Type, object>> _lazyStrategyMap;
		public RemoveStrategyFactory()
		{
			_lazyStrategyMap = new Lazy<Dictionary<Type, object>>(InitializeStrategyMap);
		}
	
		public RemoveStrategy<TEntity> GetStrategy<TEntity>()
		{
			var strategyMap = _lazyStrategyMap.Value;
			
			object strategy;
			if (strategyMap.TryGetValue(typeof(TEntity), out strategy))
            {
				return (RemoveStrategy<TEntity>) strategy;
			}
			return new DoNothingRemoveStrategy<TEntity>();
		}
		public Dictionary<Type, object> InitializeStrategyMap()
		{
			return new Dictionary<Type, object>
			{
				// CAREFUL: for Customer type, it must be a RemoveStrategy<Customer> or derived instance
				{ typeof (Customer), new CustomerRemoveStrategy() }
			};
		}
	}

		public class OperationCreate : OperationBase
		{
			public string Entity
			{
				get;
				private set;
			}
		
			[JsonProperty]
			public IReadOnlyCollection<string> Attributes
			{
				get;
				private set;
			}
		
			public OperationCreate(string entity, params string[] attributes)
			{
				Contract.Requires(entity != null);
				Contract.Requires(attributes != null);
		
				Entity = entity;
				Attributes = attributes;
			}
		}

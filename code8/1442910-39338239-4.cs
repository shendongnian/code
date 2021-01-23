     	public class OperationCreate : OperationBase
    	{
    		public string Entity
    		{
    			get;
    			private set;
    		}
    	
    		public IReadOnlyCollection<string> Attributes
    		{
    			get;
    			private set;
    		}
    	
    		public virtual bool ShouldSerializeAttributes() { return true; }
    		
    		public OperationCreate(string entity, params string[] attributes)
    		{
    			Contract.Requires(entity != null);
    			Contract.Requires(attributes != null);
    	
    			Entity = entity;
    			Attributes = attributes;
    		}
    	}
		public class OperationAssign : OperationUpdate
		{
			public OperationAssign(string entity)
				: base(entity, "ownerid")
			{   
			}
			
			public override bool ShouldSerializeAttributes() { return false; }
		}
    The base class must support this via a virtual `ShouldSerializeAttributes()` method.

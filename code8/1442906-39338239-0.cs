		public class OperationAssign : OperationUpdate
		{
			[JsonConstructor]
			OperationAssign(string entity, params string[] attributes) : this(entity)
			{
			}
			
			public OperationAssign(string entity)
				: base(entity, "ownerid")
			{   
			}
		}
    You could ignore the *value* of the deserialized attributes if you want.  The parameter need simply be present.

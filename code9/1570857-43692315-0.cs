	public class MyTrackedEntity
	{
		// Your class stuff goes here.
		private int _modifiedUserId
		public int ModifiedUserId
		{
			get
			{
				return _modifiedUserId;
			}
			set
			{
				if (value != _modifiedUserId)
					_modifiedUserId = value;
				
				// This will be heavy, cpu-wise.
				var field = this.GetType().GetField("_entityWrapper");
				if (field != null)
				{
					var wrapper  = field.GetValue(this);
					var property = wrapper.GetType().GetProperty("Context");
					var context  = (ObjectContext)property.GetValue(wrapper, null);
					DbEntityEntry entry = context.Entry(this);
					entry.State = EntityState.Modified;
				}
				else
				{
					// If you're here, your entity isn't tracked.
				}
			}
		}
	}

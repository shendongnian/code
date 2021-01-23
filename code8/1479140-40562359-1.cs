		[Serializable]
		public class EntityValueGroupViz<TEntity, TKey> : ValueGroupViz<TEntity, TKey>, IDeserializationCallback
		{
			IEnumerable<SelectedValue> cachedEntry;
	
			// Added necessary default constructor.
			public EntityValueGroupViz() : base() { }
	
			protected EntityValueGroupViz(SerializationInfo info, StreamingContext context) : base(info, context)
			{
				foreach (SerializationEntry entry in info)
				{
					switch (entry.Name)
					{
						case "SelectedValues":
							cachedEntry = (IEnumerable<SelectedValue>)entry.Value;
							break;
					}
				}
			}
			
			public override void GetObjectData(SerializationInfo info, StreamingContext context)
			{
				info.AddValue("SelectedValues", SelectedValues);
			}
	
			#region IDeserializationCallback Members
	
			public void OnDeserialization(object sender)
			{
				if (cachedEntry != null)
				{
					foreach (SelectedValue sv in cachedEntry)
						this.Value(sv);
					cachedEntry = null;
				}
			}
	
			#endregion
		}
    Sample [fiddle](https://dotnetfiddle.net/aZVdvB).

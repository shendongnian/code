		[Serializable]
		public abstract class GroupViz<T, TIn, TOut> : IViz<T>
		{
			// Added necessary default and streaming constructors
			public GroupViz()
			{
				selectedValues = new List<SelectedValue>();
			}
	
			protected GroupViz(SerializationInfo info, StreamingContext context)
			{
				selectedValues = (IList<SelectedValue>)info.GetValue("SelectedValues", typeof(IList<SelectedValue>));
			}
	
			// Allocated the list
			private IList<SelectedValue> selectedValues;
	
			public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
			{
				info.AddValue("SelectedValues", selectedValues);
			}
	
			public IEnumerable<SelectedValue> SelectedValues
			{
				get { return selectedValues.Cast<SelectedValue>(); }
			}
			
			public void Value(SelectedValue @value)
			{
				this.AddValue(@value.Value, @value.Operator);
			}
			
			private void AddValue(object @value, object vizOperator)
			{
				SelectedValue<TOut> selectedValue = new SelectedValue<TOut>((TOut)value, vizOperator);
				if (!this.selectedValues.Any(sv => sv.Equals(selectedValue)))
					this.selectedValues.Add(selectedValue);
			}
		}
	
		public abstract class ValueGroupViz<T, TIn> : GroupViz<T, TIn, TIn>
		{
			// Added necessary default and streaming constructors
			public ValueGroupViz() : base() { }
	
			protected ValueGroupViz(SerializationInfo info, StreamingContext context) : base(info, context) { }
		}
	
		[Serializable]
		public class EntityValueGroupViz<TEntity, TKey> : ValueGroupViz<TEntity, TKey>
		{
			// Added necessary default constructor.
			public EntityValueGroupViz() : base() { }
	
			protected EntityValueGroupViz(SerializationInfo info, StreamingContext context) : base(info, context) { }
		}
    As you can see, this solution is simpler, and thus recommended.
    Sample [fiddle #2](https://dotnetfiddle.net/qLg7tO).

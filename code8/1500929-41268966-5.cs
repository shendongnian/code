	public interface IVisitor
	{
		bool CanVisit(ICollection<Widget> widgets);
		
		void Visit(ICollection<Widget> widgets);
	}
	public class EmptyCollectionVisitor : IVisitor
	{
		public bool CanVisit(ICollection<Widget> widgets)
		{
			return widgets.Count == 0;
		}
		
		public void Visit(ICollection<Widget> widgets)
		{
			// Handle empty collection
		}
	}
	public class NotEmptyCollectionVisitor : IVisitor
	{
		public bool CanVisit(ICollection<Widget> widgets)
		{
			return widgets.Count > 0;
		}
		
		public void Visit(ICollection<Widget> widgets)
		{
            foreach (var widget in widgets)
            {
                // Process widget
            }
		}
	}

	var root = viewmodels
		.Where(p => p.ParentId == null)
		.FirstOrDefault();
	root.Traverse(viewmodels);
	public static class Extensions
	{
		public static void Traverse(this ProductCategoryVM node, IEnumerable<ProductCategoryVM> nodes)
		{
			var children = nodes.Where(p => p.ParentId == node.Id);
			foreach (var child in children)
			{
				child.Traverse(nodes);
			}
	
			node.Children = children;
		}
	}
  

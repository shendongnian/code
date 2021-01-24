	public IEnumerable<TreeItem> FlattenIsSelected(Tree tree)
	{
		return tree.nodeItems.Where(x => x.isSelected)
			.Concat(tree.SelectMany(t => FlattenIsSelected(t)));
	}

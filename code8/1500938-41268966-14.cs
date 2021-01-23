	var yourInputCollection = { either a list that is empty or not };
	IVisitor[] collectionVisitors = new[] { 
		new EmptyCollectionVisitor(), 
		new NotEmptyCollectionVisitor() 
	};
	foreach (var visitor in collectionVisitors)
	{
		if (visitor.CanVisit(yourInputCollection))
		{
			visitor.Visit(yourInputCollection);
		}
	}

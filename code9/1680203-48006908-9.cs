    private void DrawBooksFront(Front front)
    {
            // Loop through the pivot's items and get the content from each item's ContentTemplate.
			foreach (var item in Pivot.Items)
			{
				PivotItem pivotItem = Pivot.ContainerFromItem(item) as PivotItem;
				Grid grid = pivotItem.ContentTemplate.LoadContent() as Grid;
                // Do something with the grid.
			}
    }

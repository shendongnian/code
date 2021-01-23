	if (itemsControl.GetType() == typeof(TreeView))
	{
		var originalStyle = itemsControl.Style;
		var newStyle = new Style();
		newStyle.BasedOn = originalStyle;
		newStyle.Setters.Add(new EventSetter(PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(ItemsControl_PreviewMouseLeftButtonDown)));
		newStyle.Setters.Add(new EventSetter(PreviewMouseMoveEvent, new MouseEventHandler(ItemsControl_PreviewMouseMove)));
		newStyle.Setters.Add(new EventSetter(PreviewMouseLeftButtonUpEvent, new MouseButtonEventHandler(ItemsControl_PreviewMouseLeftButtonUp)));
		newStyle.Setters.Add(new EventSetter(PreviewDropEvent, new DragEventHandler(ItemsControl_PreviewDrop)));
		newStyle.Setters.Add(new EventSetter(PreviewQueryContinueDragEvent, new QueryContinueDragEventHandler(ItemsControl_PreviewQueryContinueDrag)));
		newStyle.Setters.Add(new EventSetter(PreviewDragEnterEvent, new DragEventHandler(ItemsControl_PreviewDragEnter)));
		newStyle.Setters.Add(new EventSetter(PreviewDragOverEvent, new DragEventHandler(ItemsControl_PreviewDragOver)));
		newStyle.Setters.Add(new EventSetter(DragLeaveEvent, new DragEventHandler(ItemsControl_DragLeave)));
		itemsControl.ItemContainerStyle = newStyle;
	}

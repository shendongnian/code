		ItemTappedCommand = new Command((object model) => {
			if (model != null && model is ItemTappedEventArgs) {
				if (!((Model)((ItemTappedEventArgs)model).Item).Selected)
					SelectedItemsCounter++;
				else
					SelectedItemsCounter--;
				
				((Model)((ItemTappedEventArgs)model).Item).Selected = !((Model)((ItemTappedEventArgs)model).Item).Selected;
			}
		});

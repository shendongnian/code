     class CustomEntryRenderer : EntryRenderer
	 {
		private CustomEntry customEntry;
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
            base.OnElementChanged (e);
            if (Control != null) 
            {                
                Control.ImeOptions = ImeAction.Done;
				Control.EditorAction += (sender, args) => {
					if (args.ActionId == ImeAction.Done) {					
						var entry = (CustomEntry)Element;
						entry.DonePressed();
					}
				};
			}		

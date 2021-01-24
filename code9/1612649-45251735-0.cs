    this.PropertyChanging += async (object sender, PropertyChangingEventArgs e) =>
			{
				if (e.PropertyName == "CurrentPage")
				{
					if (this.CurrentPage == null)
						return;
.....
					
					
				}
			};

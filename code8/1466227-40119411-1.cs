		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);
			if (segue.DestinationViewController is WebPage)
			{
				WebPage web = (WebPage)segue.DestinationViewController;
				web.SelectedRestaurant = this.SelectedRestaurant;
			}
		}

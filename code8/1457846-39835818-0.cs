	public class MyLinkProvider : Sitecore.Links.LinkProvider
	{
		public override string GetItemUrl(Item item, UrlOptions options)
		{
			var templateID = new ID("<your template Id >");
			if (item == null)
			{
				return string.Empty;
			}
			Assert.ArgumentNotNull(options, "options");
			if (item.TemplateID == templateID) 
			{
				// Build your custom url here
				return "custom url";
			}
			else 
			{
				return base.GetItemUrl(item, options);
			}
		}
	}

	public class  publishedContentapiController  : UmbracoApiController
	{
		public IHttpActionResult GetComments()
		{
			// Create an UmbracoHelper for retrieving published content
			var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
			// Get all comments from the Umbraco tree (this is not a optimized way of doing this, since it queries the complete Umbraco tree)
			var comments = umbracoHelper.TypedContentAtRoot().DescendantsOrSelf("comment");		
			// Map the found nodes from IPublishedContent to a strongly typed object of type Comment (defined below)
			var mappedComments = comments.Select(x => new Comment{
				Name = x.Name,								// Map name of the document
				Date = x.CreatedTime,						// Map createdtime
				Text = x.GetPropertyValue<string>("text")	// Map custom property "text"
			});
			return Ok(mappedComments);
		}
		private class Comment
		{
			public string Name { get; set; }
			public DateTime Date { get; set; }
			public string Text { get; set; }
		}
	}
    

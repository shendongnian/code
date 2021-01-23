	public abstract class HtmlTag
	{
		private readonly String _tag;
        //allow different type of tags to be rendered
		protected HtmlTag(String tag)
		{
			if (String.IsNullOrWhiteSpace(tag)) 
				throw new ArgumentException("Value cannot be null or whitespace.", "tag");
			_tag = tag;
		}
        //require a VehicleStatus for rendering to an HtmlString
		public String ToHtmlString( VehicleStatus vehicleStatus )
		{
			var tag = new TagBuilder( _tag );
			this.CreateTag( tag, vehicleStatus );
			return tag.ToString();
		}
        //require subclasses to implement the CreateTag method
        //this method will allow subclasses to modify the tag builder as needed
        //depending on the vehicle status
		protected abstract void CreateTag( TagBuilder tagBuilder, VehicleStatus vehicleStatus );
	}

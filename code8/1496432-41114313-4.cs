	public static class DivHtmlHelperExtensions
	{
		public static IHtmlString Div( this HtmlHelper htmlHelper, VehicleStatus vehicleStatus, HtmlTag htmlTag )
		{
			//simply return the HtmlString representation of your HtmlTag you passed in
			return new HtmlString( htmlTag.ToHtmlString( vehicleStatus ) );
		}
		//call this method likeso (from a view):
		//@Html.Div(vehicleStatus, new PanelDiv());
		//@Html.Div(vehicleStatus, new GlyphiconDiv());
	}

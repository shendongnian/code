	public abstract class Div : HtmlTag
	{
		private readonly String _className;
		private readonly String _trueCssClass;
		private readonly String _falseCssClass;
		protected Div( String className, String trueCssClass, String falseCssClass )
			: base( "div" )
		{
			_className = className;
			_trueCssClass = trueCssClass;
			_falseCssClass = falseCssClass;
		}
        //the div will use the constructing parameters to populate the classes instead
		protected override void CreateTag( TagBuilder tagBuilder, VehicleStatus vehicleStatus )
		{
			tagBuilder.AddCssClass( _className );
			tagBuilder.AddCssClass( vehicleStatus == VehicleStatus.Success 
				? _trueCssClass 
				: _falseCssClass );
		}
	}
    //and your subclass:
	public class PanelDiv : Div
	{
		public PanelDiv()
			: base( "panel", "panel-success", "panel-danger" )
		{
		}
	}

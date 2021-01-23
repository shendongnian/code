	public class PanelDiv : Div
	{
		protected override void CreateTag( TagBuilder tagBuilder, VehicleStatus vehicleStatus )
		{
			tagBuilder.AddCssClass( "panel" );
			tagBuilder.AddCssClass(vehicleStatus == VehicleStatus.Success 
				? "panel-success" 
				: "panel-danger");
		}
	}
	public class GlyphiconDiv : Div
	{
		protected override void CreateTag( TagBuilder tagBuilder, VehicleStatus vehicleStatus )
		{
			tagBuilder.AddCssClass( "glyphicon" );
			tagBuilder.AddCssClass( vehicleStatus == VehicleStatus.Success 
				? "glyphicon-remove-circle" 
				: "glyphicon-add-circle" );
		}
	}

	internal class UnitName {
		internal string name; 
		internal GraphicsUnit unit;
		internal static readonly UnitName[] names = new UnitName[] {
				new UnitName("world", GraphicsUnit.World), // made up
				new UnitName("display", GraphicsUnit.Display), // made up
				new UnitName("px", GraphicsUnit.Pixel),
				new UnitName("pt", GraphicsUnit.Point),
				new UnitName("in", GraphicsUnit.Inch),
				new UnitName("doc", GraphicsUnit.Document), // made up
				new UnitName("mm", GraphicsUnit.Millimeter),
			};
		internal UnitName(string name, GraphicsUnit unit) {
			this.name = name;
			this.unit = unit;
		}
	}

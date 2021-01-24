	public class layer
	{
		public string layername { get; set; }
		public string Linetype { get; set; }
		public int? Layercolor { get; set; }
		public string Lineweight { get; set; }
		public layer Override(Modifier modifier)
		{
			layer newLayer = new layer();
			newLayer.layername = this.layername;
			newLayer.Layercolor = modifier.color;
			newLayer.Linetype = modifier.Linetype;
			newLayer.Lineweight = modifier.Lineweight;
			return newLayer;
		}
		public override string ToString()
		{
			return layername;
		}
	}

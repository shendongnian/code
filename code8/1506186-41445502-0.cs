	public static class PropriedadeAnexada
	{
		public static readonly DependencyProperty GeometriaProperty
			= DependencyProperty.RegisterAttached(
				"Geometria",
				typeof(Geometry),
				typeof(PropriedadeAnexada),
				new FrameworkPropertyMetadata(
					default(Geometry),
					FrameworkPropertyMetadataOptions.AffectsRender
					| FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
				)
			);
		public static Geometry GetGeometria (DependencyObject element)
		{
			return (Geometry)element.GetValue(GeometriaProperty);
		}
		public static void SetGeometria (DependencyObject element, Geometry value)
		{
			element.SetValue(GeometriaProperty, value);
		}
    }

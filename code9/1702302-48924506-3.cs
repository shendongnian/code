	namespace Viewport3DExtensions
	{
		public static class Implementation
		{
			public static void AlphaSortModels(this System.Windows.Controls.Viewport3D viewport3D)
			{
				var projectionCamera = viewport3D.Camera as System.Windows.Media.Media3D.ProjectionCamera;
				if (projectionCamera != null)
				{
					var modelVisual3Ds = new System.Collections.Generic.List<System.Windows.Media.Media3D.ModelVisual3D>();
					foreach (var c in viewport3D.Children)
					{
						var m = c as System.Windows.Media.Media3D.ModelVisual3D;
						if (m != null)
							modelVisual3Ds.Add(m);
					}
					// note:
					//  the following method works well most of the time but sometimes the sort is wrong as the sort is simply based on model bounds,
					//  to get rid of artefacts we would need something like binary space partioning
					SceneHelper.SceneSortingHelper.AlphaSort(
						projectionCamera.Position,
						modelVisual3Ds,
						new System.Windows.Media.Media3D.Transform3DGroup()
					);
					viewport3D.Children.Clear();
					foreach (var c in modelVisual3Ds)
						viewport3D.Children.Add(c);
				}
			}
		}
	}

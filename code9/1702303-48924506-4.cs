	// original class taken from
    // https://web.archive.org/web/20071201135137/http://blogs.msdn.com/pantal/archive/2007/07/23/sorting-for-wpf-3d-transparency.aspx
	public static class SceneSortingHelper
	{
		/// <summary>
		/// Sort Modelgroups in farthest to closest order, to enable transparency
		/// Should be applied whenever the scene is significantly re-oriented
		/// </summary>
		public static void AlphaSort(Point3D CameraPosition, 
			System.Collections.Generic.List<System.Windows.Media.Media3D.ModelVisual3D> ModelVisual3Ds, Transform3D WorldTransform)
		{
			ArrayList list = new ArrayList();
			foreach (var m in ModelVisual3Ds)
			{
				var location =
					WorldTransform.TransformBounds(
						m.Transform.TransformBounds(
							m.Content.Transform.TransformBounds(
								m.Content.Bounds
							)
						)
					).Location;
				double distance = Point3D.Subtract(CameraPosition, location).Length;
				list.Add(new ModelVisual3DDistance(distance, m));
			}
			list.Sort(new DistanceComparer(SortDirection.FarToNear));
			ModelVisual3Ds.Clear();
			foreach (ModelVisual3DDistance d in list)
			{
				ModelVisual3Ds.Add(d.modelVisual3D);
			}
		}
		private class ModelVisual3DDistance
		{
			public ModelVisual3DDistance(double distance, ModelVisual3D modelVisual3D)
			{
				this.distance = distance;
				this.modelVisual3D = modelVisual3D;
			}
			public double distance;
			public ModelVisual3D modelVisual3D;
		}
		private enum SortDirection
		{
			NearToFar,
			FarToNear
		}
		private class DistanceComparer : IComparer
		{
			public DistanceComparer(SortDirection sortDirection)
			{
				_sortDirection = sortDirection;
			}
			int IComparer.Compare(Object o1, Object o2)
			{
				double x1 = ((ModelVisual3DDistance)o1).distance;
				double x2 = ((ModelVisual3DDistance)o2).distance;
				if (_sortDirection == SortDirection.FarToNear)
				{
					if (x1 > x2)
						return -1;
					else
					if (x1 < x2)
						return 1;
					else
						return 0;
				}
				else
				{
					if (x1 > x2)
						return 1;
					else
					if (x1 < x2)
						return -1;
					else
						return 0;
				}
			}
			private SortDirection _sortDirection;
		}
	}

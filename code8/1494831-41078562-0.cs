    	/// <summary>
		/// Calculates a contour point of the four-pointed star.
		/// </summary>
		/// <param name="x">The abscissa of the contour point.</param>
		/// <returns>Returns the ordinate of the contour point.</returns>
		private static double StarContour(double x)
		{
			return -0.190983d + (0.427051d * Math.Sqrt(0.923607d + (0.647214d * x) - (1.37082d * x * x)));
		}
		/// <summary>
		/// Tests whether a point is inside the four-pointed star of the given radius.
		/// </summary>
		/// <param name="radius">The radius of the star.</param>
		/// <param name="x">The abscissa of the point to test.</param>
		/// <param name="y">The ordinate of the point to test.</param>
		/// <returns>Returns <see langword="true" /> if the point (<paramref name="x" />, <paramref name="y" />
		/// is inside or on the contour of the star with the given <paramref name="radius" />;
		/// otherwise, if the point is outside the star, returns <see langword="false" />.</returns>
		private static bool InFourStar(double radius, double x, double y)
		{
			double min = Math.Abs(x);
			double max = Math.Abs(y);
			if (min > max)
			{
				// swap min and max
				double h = min;
				min = max;
				max = h;
			}
			return min <= radius * StarContour(max / radius);
		}

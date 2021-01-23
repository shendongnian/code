    	/// <summary>
		/// Draws the outline of a four-pointed star of given radius and color.
		/// </summary>
		/// <param name="radius">The radius of the star.</param>
		/// <param name="color">The color of the outline.</param>
		private void DrawFourStar(double radius, Color color)
		{
			const double Offset = 0.236068d;
			for (int x = (int)(Offset * radius); x < radius; ++x)
			{
				int y = (int)(radius * StarContour(x / radius));
				this.CirclePoint(x, y, color);
			}
		}
		/// <summary>
		/// Draws sample points inside or on a four-pointed star contour of given radius.
		/// </summary>
		/// <param name="radius">The radius of the star.</param>
		/// <param name="color">The color of the sample points.</param>
		private void DrawSamplesInStar(double radius, Color color)
		{
			const int SamplingStep = 10;
			for (int x = (int)(-radius); x < radius; x += SamplingStep)
			{
				for (int y = (int)(-radius); y < radius; y += SamplingStep)
				{
					if (InFourStar(radius, x, y))
					{
						this.bitmap.SetPixel(x + this.x0, y + this.y0, color);
					}
				}
			}
		}

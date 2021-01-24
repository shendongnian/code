	static Bitmap DrawChart(float[] Values, int Width, int Height)
	{
		var n = Values.Count();
		if (n % 2 == 1) throw new Exception("Invalid data");
		//Split the data into lists for easy access
		var x = new List<float>();
		var y = new List<float>();
		for (int i = 0; i < n - 1; i += 2)
		{
			x.Add(Values[i]);
			y.Add(Values[i + 1]);
		}
		//Chart axis limits, change here to get custom ranges like -1,+1
		var minx = x.Min();
		var miny = y.Min();
		var maxx = x.Max();
		var maxy = y.Max();
		var dxOld = maxx - minx;
		var dyOld = maxy - miny;
		//Rescale the y-Range to add a border at the top and bottom
		miny -= dyOld * 0.2f;
		maxy += dyOld * 0.2f;
		var dxNew = (float)Width;
		var dyNew = (float)Height;
		//Draw the data
		Bitmap res = new Bitmap(Width, Height);
		using (var g = Graphics.FromImage(res))
		{
			g.Clear(Color.Black);
			for (int i = 0; i < x.Count; i++)
			{
				//Calculate the coordinates
				var px = Interpolate(x[i], minx, maxx, 0, dxNew);
				var py = Interpolate(y[i], miny, maxy, 0, dyNew);
				//Draw, put the ellipse center around the point
				g.FillEllipse(Brushes.ForestGreen, px - 1.0f, py - 1.0f, 2.0f, 2.0f);
			}
		}
		return res;
	}
	static float Interpolate(float Value, float OldMin, float OldMax, float NewMin, float NewMax)
	{
		//Linear interpolation
		return ((NewMax - NewMin) / (OldMax - OldMin)) * (Value - OldMin) + NewMin;
	}

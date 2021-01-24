	private void ComputeCoordinates()
	{
		// Convert to polar coordinates.
		double r = CoerceValue(Math.Sqrt((X * X) + (Y * Y)), 0d, 1d);  // Radius;
		double a = Math.Atan2(Y, X);  // Angle (in radians);
		// Apply modifiers.
		double value = ComputeModifiers(r);
		// Convert to cartesian coordinates.
		double x = value * Math.Cos(a);
		double y = value * Math.Sin(a);
		// Apply axis independent modifiers.
		if (InvertX) x = -x;
		if (InvertY) y = -y;
		// Set calculated values to property values;
		_computedX = x;
		_computedY = y;
	}
	private double ComputeModifiers(double value)
	{
		// Apply dead-zone and saturation.
		if (DeadZone > 0d || Saturation < 1d)
		{
			double edgeSpace = (1 - Saturation) + DeadZone;
			if (edgeSpace < 1d)
			{
				double multiplier = 1 / (1 - edgeSpace);
				value = (value - DeadZone) * multiplier;
				value = CoerceValue(value, 0d, 1d);
			}
			else
			{
				value = Math.Round(value);
			}
		}
		// Apply sensitivity.
		if (Sensitivity != 0d)
		{
			value = value + ((value - Math.Sin(value * (Math.PI / 2))) * (Sensitivity * 2));
			value = CoerceValue(value, 0d, 1d);
		}
		// Apply range.
		if (Range < 1d)
		{
			value = value * Range;
		}
		// Return calculated value.
		return CoerceValue(value, 0d, 1d);
	}

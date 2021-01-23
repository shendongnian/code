    double totalScore = bytTest1 + bytTest2 + bytTest3;
	double lowest = Math.Min(Math.Min(bytTest1, bytTest2), bytTest3);
	if (chkDropLowest.IsChecked == true)
	{
        // Drop the lowest test
		fltAverage = (totalScore - lowest) / 2;
	}
	else
	{
        // Include all three tests
		fltAverage = (totalScore) / 3;
	}

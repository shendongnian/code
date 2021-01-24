    public static class MyObjectExtensions
    {
	   public static bool ShouldWeDeleteThisExcelLine(this object input)
	   {
		   string stringInput = (string) input;
		   if (string.IsNullOrWhiteSpace(stringInput))
			   return true;
     		double someValue;
		    return double.TryParse(stringInput, out someValue) == false;
	   }
    }

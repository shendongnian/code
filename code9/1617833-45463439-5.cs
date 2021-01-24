	public class MyHelpers
	{
		public static bool ShouldWeDeleteThisExcelLine(object input)
		{
			string stringInput = (string) input;
			if (string.IsNullOrWhiteSpace(stringInput))
				return true;
			double someValue;
			return double.TryParse(stringInput, out someValue) == false;
		}
	}
	if (MyHelpers.ShouldWeDeleteThisExcelLine(
	   dgUpdatesPrices.Rows[e.RowIndex].Cells["NSPSPRICE"].Value))
	{      
		/* delete it */ 
	}

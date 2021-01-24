	public class Program
	{
		static public void Main()
		{
			HexString bdk1 = new HexString("8D10DA193E98524379264ADFFD043632");
			HexString bdk2 = new HexString("8C339F7EB7339FAC87FAF0478B500422");
			
			const string expected = "0123456789ABCDEFFEDCBA9876543210";
			
			HexString actual = bdk1 ^ bdk2;
			
			Console.WriteLine("Expected: " + expected);
			Console.WriteLine("Actual  : " + actual);
			
			Console.ReadLine(); 
		}

	public interface I1
	{
		int One { get; set; }
	}
	public interface I2
	{
		int Two { get; set; }
	}
	public interface I3 : I1, I2
	{
		int Three { get; set; }
	}
	
    // Implementation of I3 (which inherits I1 and I2)
	public class Foo : I3
	{
		public int One { get; set; }
		public int Two { get; set; }
		public int Three { get; set; }
	}

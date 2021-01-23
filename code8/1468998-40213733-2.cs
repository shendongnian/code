	public class MyBinaryReader : BinaryReader
	{
		public MyBinaryReader(Stream input) : base(input)
		{
		}
	
		public MyBinaryReader(Stream input, Encoding encoding) : base(input, encoding)
		{
		}
	
		public MyBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
		{
		}
	
		public override long ReadInt64()
		{
			// Fill in your own custom logic here.
		}
	}

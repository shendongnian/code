    public class HexString
	{
		private byte[] _data;
		
		public HexString(byte[] data)
		{
			_data = data;
		}
		public HexString(string data)
		{
			if ((data.Length & 1)!= 0) throw new ArgumentException("Hex string must have an even number of digits.");
			
			_data = Enumerable.Range(0, data.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(data.Substring(x, 2), 16))
                .ToArray();
		}
    }

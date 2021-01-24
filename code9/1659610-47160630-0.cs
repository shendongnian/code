    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		float f = 9876f;
    		var bytes = GetBigEndian(f);
    		Console.WriteLine("{0} => {1}", f, BitConverter.ToString(bytes));
    		
    		Console.WriteLine("{0} => {1}", f, GetFloatFromBigEndian(bytes));
    	}
    	static byte[] GetBigEndian(float v) {
    		byte[] bytes = BitConverter.GetBytes(v);
    		if (BitConverter.IsLittleEndian)
    			Array.Reverse(bytes);
    		return bytes;
    	}
    	static float GetFloatFromBigEndian(byte[] bytes) {
    		// We have to reverse
    		Array.Reverse(bytes);
    		return BitConverter.ToSingle(bytes, 0);
    	}
    }

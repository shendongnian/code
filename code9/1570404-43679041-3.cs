	public class Program
	{
		public static void Main()
		{
			Console.WriteLine($"sizeof(_INFO): {Marshal.SizeOf(typeof(_INFO))}");
			Console.WriteLine($"sizeof(Identification): {Marshal.SizeOf(typeof(Identification))}");
			Console.WriteLine($"sizeof(Buffer): {Marshal.SizeOf(typeof(Buffer))}");
			Console.WriteLine($"sizeof(_HEADER): {Marshal.SizeOf(typeof(_HEADER))}");
			Console.WriteLine();
			
			Console.WriteLine("To prove that it behaves union-like:");
			var header = new _HEADER();
			header.Identification.Protocol = 5;
			Console.WriteLine($"header.Identification.Protocol: {header.Identification.Protocol}");
			Console.WriteLine($"header.Buffer.Width: {header.Buffer.Width}");
		}
		
		public const int MAX_ = 10;
	}
	
	public enum TJ { _44, _42 }
	
	public enum _TYPE { _OFF, _ON }
	
	public enum _HEADER_TYPE { _HEADER_TYPE_IDENTIFICATION, _HEADER_TYPE_PING }
	
	[StructLayout(LayoutKind.Explicit, Pack=4, Size=20)]
	public struct _INFO
	{
	    [FieldOffset(0)] public TJ S;
	    [FieldOffset(4)] public long Q;
	    [FieldOffset(12)] public long R1;   
	}
	
	[StructLayout(LayoutKind.Explicit, Pack=4, Size=32+2*8*Program.MAX_)]
	public struct Identification
	{
	    [FieldOffset(0)] public long Protocol;
	    [FieldOffset(8)] public _TYPE CType;
	    [FieldOffset(12)] public _INFO InfoDesired;
		
		[MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = Program.MAX_)]
		[FieldOffset(32)] public long[] ResolutionX;
		
		[MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = Program.MAX_)]
		[FieldOffset(32 + Program.MAX_ * 8)] public long[] ResolutionY;
	}
	
	[StructLayout(LayoutKind.Explicit, Pack=4, Size=32)]
	public struct Buffer
	{
	    [FieldOffset(0)] public long Width;
	    [FieldOffset(4)] public _TYPE Type;
	    [FieldOffset(12)] public _INFO Info;
	}
	
	[StructLayout(LayoutKind.Explicit, Pack=4, Size=204)]
	public struct _HEADER
	{
	    // First slot (4 bytes)
	    [FieldOffset(0)] public _HEADER_TYPE HeaderType;
	
	    // Second slot (8 bytes)
	    [FieldOffset(4)] public ulong cc;
	
	    // The next 2 structs share the third slot (204 bytes)
	    [FieldOffset(12)] public Identification Identification;
	    [FieldOffset(12)] public Buffer Buffer;
	}

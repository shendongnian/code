		[StructLayout(LayoutKind.Sequential)]
		class Obj
		{
			public int A;
		}
		var obj = new Obj();
		var gc = GCHandle.Alloc(obj, GCHandleType.Pinned);
		IntPtr interior = gc.AddrOfPinnedObject();
		Marshal.WriteInt32(interior, 0, 16);
		Console.WriteLine(obj.A);

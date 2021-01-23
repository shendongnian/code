	private class Interop
	{
		//This method exists just to provide its signature, it cannot be called directly
		[DllImport("\0", CallingConvention = CallingConvention.Cdecl)]
		public static extern int sprintf(StringBuilder buffer, string format, __arglist);
		
		//Loads a DLL library
		[DllImport("kernel32", SetLastError=true, CharSet = CharSet.Ansi)]
		public static extern IntPtr LoadLibrary(string lpFileName);
		
		//Obtains a pointer to a function from a library
		[DllImport("kernel32", SetLastError=true, CharSet=CharSet.Ansi)]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
	}
	var mi = typeof(Interop).GetMethod("sprintf");
	byte[] sig = typeof(Interop).Module.ResolveSignature(mi.MetadataToken);
    //the signature of the method is 05-02-08-12-80-8D-0E (varags, 2 parameters, returning int, class parameter, string parameter)
	
	var lib = Interop.LoadLibrary("msvcrt.dll");
	var proc = Interop.GetProcAddress(lib, "sprintf");
	IntPtr managed;
	fixed(byte* sigb = sig)
	{
		//the signature is passed to the method
		managed = Marshal.GetManagedThunkForUnmanagedMethodPtr(proc, (IntPtr)sigb, sig.Length);
	}

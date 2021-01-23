	public static class PInvoke
	{ 
    public const string file = "/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL";
    #if __MAC__
   
    [DllImport(file, EntryPoint = "glBindVertexArray", ExactSpelling = true)]
		internal extern static void BindVertexArray(UInt32 array);
    #endif
    }

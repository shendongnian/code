	public static class PInvoke
	{ 
    public const string file = "/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL";
    #if __MAC__
   
    [DllImport(file, EntryPoint = "glGenVertexArrays", ExactSpelling = true)]
    internal extern static unsafe void GenVertexArrays(Int32 n, [OutAttribute] UInt32* arrays);
    #endif
    }

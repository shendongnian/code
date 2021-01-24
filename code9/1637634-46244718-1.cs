    using System.Text;
    using System.Runtime.InteropServices;
        
    namespace MySpace
    {    	
    	class MyDll {
    		[DllImport("MyStrCopy.dll", CharSet = CharSet.Ansi)]
    		public static extern void MyStrCopy(
                 StringBuilder  dst_str, 
                 string         src_str, 
                 int            dst_len);		
    		static void ExampleUsage() {
        		int           dest_len   = 100;
        		StringBuilder dest_str   = new StringBuilder(dest_len);
        		string        source     = "this is a string";
        		MyStrCopy(dest_str, source, dest_len);
        		return;
     		}		
    		
    	} //class
    } //namespace

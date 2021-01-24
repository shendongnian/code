    public static class CursorHook
    {
         
    
        private static IntPtr programCursor = IntPtr.Zero;
        private static IntPtr systemCursor = IntPtr.Zero;
        private static Cursor ProgramCursor = null;
        private static Cursor DefaultCursor = null;
        public static void Init()
        {
            
            
            using(MemoryStream ms = new MemoryStream(resourceCursor.marker_cursor2))
            {
                ProgramCursor = new Cursor(ms);
            }
            DefaultCursor = new Cursor(Cursors.IBeam.CopyHandle());
            
        }
        public static void Start()
        {
            //as the GC has likely invalidated the IntPtr, each time you have to assign it anew
            programCursor = ProgramCursor.CopyHandle();
             SetSystemCursor(programCursor, UNS_OCR_IBEAM);
        }
        public static void Stop()
        {
            //as the GC has likely invalidated the IntPtr, each time you have to assign it anew
            systemCursor = DefaultCursor.CopyHandle();
            SetSystemCursor(systemCursor, UNS_OCR_IBEAM);         
            
          
        }
        public static void Dispose()
        {
                      
        }
        private const int OCR_IBEAM = 32513;
        private const uint UNS_OCR_IBEAM = OCR_IBEAM;
        private static IntPtr PTR_OCR_IBEAM = new IntPtr(OCR_IBEAM);
       
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SetSystemCursor(IntPtr hCursor, uint id);
        
        
    }

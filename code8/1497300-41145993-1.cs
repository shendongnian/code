    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    
    namespace ComLib
    {
        [ComVisible(true)] // needs to be marked ComVisible 
        [Guid("ad4c28c9-4612-4ac3-8ca4-04a343f4f2b9")] // generate your own
        public class LogWriter
        {
            public void WriteLine(string line)
            {
                using (var log = new StreamWriter(File.OpenWrite(@"c:\log.file")))
                {
                    log.WriteLine(line);
                }
            }
        }
    }

    using Foundation;
    using ObjCRuntime;
    
    namespace Foundation
    {
        [Category]
        [BaseType(typeof(NSString))]
        public interface NSStringWriteToFileExtension
        {
            [Export("writeToFile:atomically:encoding:error:")]
            bool Write(string filePath, bool atomically, NSStringEncoding encoding, out NSError error);
        }
    }

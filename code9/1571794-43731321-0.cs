    [assembly: Xamarin.Forms.Dependency (typeof (FileService_iOS))]
    namespace MyApp
    {
        public class FileService_iOS : IFileService
        {
            string SaveFile(Stream s)
            {
                // Implement here and return the path to the saved file
            }
        }
    }

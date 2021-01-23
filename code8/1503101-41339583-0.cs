    namespace MyApp.Common.Interfaces
    {
        public interface IDataViewer
        {
            void showPhoto(string AttachmentName, byte[] AttachmentBytes);
            string ImageExists(string Filename, byte[] ImageData);
        }
    }

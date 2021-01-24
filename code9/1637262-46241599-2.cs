    public interface IFileSystem {
        void Delete(string path);
        //...code removed for brevity
    }
    public class ServerFileSystemWrapper : IFileSystem {
        public void Delete(string path) {
            System.IO.File.Delete(Server.MapPath(path));
        }
        //...code removed for brevity
    }

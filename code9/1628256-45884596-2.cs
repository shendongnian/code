    public interface IFilePath {
        string MapPath(string folder, string filepath);
    }
    public class ServerPath : IFilePath {
        public virtual string MapPath(string folder, string filepath) {
                Console.WriteLine("ServerPath");
                return (System.Web.Hosting.HostingEnvironment.MapPath(folder + filepath));
        }
    }

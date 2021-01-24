    public interface IServerPath {
        string MapPath(string folder, string filepath);
    }
    public class ServerPath : IServerParth {
        public virtual string MapPath(string folder, string filepath) {
                Console.WriteLine("ServerPath");
                return (System.Web.Hosting.HostingEnvironment.MapPath(folder + filepath));
        }
    }

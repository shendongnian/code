    public interface IPathProvider {
        string MapPath(string path);
    }
    
    public class PathProvider : IPathProvider {
        private IHostingEnvironment _hostingEnvironment;
    
        public PathProvider(IHostingEnvironment environment) {
            _hostingEnvironment = environment;
        }
    
        public string MapPath(string path) {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, path);
            return filePath;
        }
    }

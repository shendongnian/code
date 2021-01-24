    public class DefaultProductsCsvReader : IProductsCsvReader {
        public string[] ReadAllLines(string virtualPath) {
            var productFilePath = HttpContext.Current.Server.MapPath(virtualPath);
            String[] csvData = File.ReadAllLines(productFilePath);
            return csvData;
        }
    }

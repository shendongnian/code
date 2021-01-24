    public class AppUtilsSubsitute : ILogger {
        public void LogException(string func, Exception ex) => Write("Exception", ex.ToJson());
    
        public void LogError(string err) => Write("Error", err);
    
        public void LogInfo(string info) => Write("Info", info);
    
        public void LogWarning(string info) => Write("Warning", info);
    
        public void LogCypherQuery(string func, ICypherFluentQuery query) => Write(func, query.ToJson());
    
        static void Write(string logType, string message) {
            var dictionary = new Dictionary<string, string> { { logType, message } };
            var assembly = Assembly.GetExecutingAssembly();
            using (var writer = new StreamWriter(assembly.Location + "Machine.Specifications.log")) {
                writer.Write(dictionary.ToJson());
            }
        }
    
        public Dictionary<string, string> Log() {
            var assembly = Assembly.GetExecutingAssembly();
            Dictionary<string, string> content;
            using (var reader = new StreamReader(assembly.GetManifestResourceStream("Machine.Specifications.log"))) {
                content = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
            }
            return content;
        }
    }

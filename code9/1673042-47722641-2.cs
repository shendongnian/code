    public class WpfInspector : MarshalByRefObject {
        public string[] Inspect(string path) {
            ValidatePath(path);
            var assembly = Assembly.LoadFrom(path);
            var types = assembly.GetTypes();
            List<string> methods = new List<string>();
            foreach (var type in types) {
                foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)) {
                    methods.Add(method.Name);
                }
            }
            return methods.ToArray();
        }
        private void ValidatePath(string path) {
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (!System.IO.File.Exists(path))
                throw new ArgumentException($"path \"{path}\" does not exist");
        }
    }

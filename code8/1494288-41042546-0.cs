    internal class Program {
        private static void Main(string[] args) {
            if (args.Length != 1) {
                Console.WriteLine("Incorrect usage!");
                return;
            }
            var extensions = GetExecutableExtensions(args[0]);
            var paths = GetPaths();
            var exeFile = GetFirstExecutableFile(args[0], extensions, paths);
            if (exeFile == null) {
                Console.WriteLine("No file found!");
            }
            else {
                Console.WriteLine(exeFile);
            }
        }
        private static string GetFirstExecutableFile(string file, string[] extensions, string[] paths) {
            foreach (var path in paths) {
                var filename = Path.Combine(path, file);
                if (extensions.Length == 0) {
                    if (File.Exists(filename)) {
                        return filename;
                    }
                }
                else {
                    foreach (var ext in extensions) {
                        filename = Path.Combine(path, file + ext);
                        if (File.Exists(filename)) {
                            return filename;
                        }
                    }
                }
            }
            return null;
        }
        private static string[] GetExecutableExtensions(string file) {
            var data = GetCmdOutput("echo %PATHEXT%");
            var arr = data.TrimEnd('\n', '\r').Split(new [] {';'}, StringSplitOptions.RemoveEmptyEntries);
            //If the command passed in ends with a executable extension then we dont need to test all extensions so set it to emtpy array
            foreach (var ext in arr) {
                if (file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)) {
                    return new string[0];
                }
            }
            return arr;
        }
        private static string[] GetPaths() {
            var data = GetCmdOutput("echo %PATH%");
            return data.TrimEnd('\n', '\r').Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        }
        private static string GetCmdOutput(string cmd) {
            using (var proc = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = "cmd.exe",
                    Arguments = "/c " + cmd,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            }) {
                proc.Start();
                return proc.StandardOutput.ReadToEnd();
            }
        }
    }

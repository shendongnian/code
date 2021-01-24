        public class Helper
        {
            public static void Inject(IntPtr windowHandle, Assembly assembly, string className, string methodName)
            {
                var location = Assembly.GetEntryAssembly().Location;
                var directory = Path.GetDirectoryName(location);
                var file = Path.Combine(directory, "HelperDlls", "ManagedInjectorLauncher" + "64-4.0" + ".exe");
                Debug.WriteLine(file + " " + windowHandle + " \"" + assembly.Location + "\" \"" + className + "\" \"" + methodName + "\"");
                Process.Start(file, windowHandle + " \"" + assembly.Location + "\" \"" + className + "\" \"" + methodName + "\"");
            }
        }

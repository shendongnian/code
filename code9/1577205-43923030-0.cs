    public class AppStartupHook
    {
        [STAThread]
        public static void Main(string[] args)
        {
            ClickOnceSucks();
            App.Main();
        }
        /// <summary>
        /// Copies the embedded resources into the application path before startup.
        /// </summary>
        private static void ClickOnceSucks()
        {
            const string folderName      = "ClickOnceSucks";
            const string structureFormat = "{0}.{1}.";
            var assembly        = Assembly.GetExecutingAssembly();
            var resourceFolder  = structureFormat.FormatCurrent(assembly.GetName().Name, folderName);
            //Find all resources in the clickoncesucks folder and copy them to our path.
            assembly
                .GetManifestResourceNames()
                .Where(each => each.StartsWith(resourceFolder, StringComparison.Ordinal))
                .Select(each => new
                {
                    Name = each.Replace(resourceFolder, string.Empty),
                    Data = assembly.GetManifestResourceStream(each)
                })
                .Where(each => !File.Exists(each.Name))
                .ForEach(each =>
                {
                    using (var fileStream = new FileStream(each.Name, FileMode.Create, FileAccess.Write))
                        each.Data.CopyTo(fileStream);
                });
        }
    }

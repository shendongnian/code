    public class Program
    {
        private const string SourcePath = "\\\\ClickOnceDeployDir";
        private const string TargetPath = "C:\\Users\\UserName\\Documents\\ClickOnceTargetDir";
        public static void Main(string[] args)
        {
            var sourceDirectory = new DirectoryInfo(SourcePath);
            var targetDirectory = new DirectoryInfo(TargetPath);
            // you can omit this step if you would like to do the renaming in-place
            Copy(sourceDirectory, targetDirectory);
            foreach (var file in targetDirectory.GetFiles("*.deploy", SearchOption.AllDirectories))
            {
                var directoryName = file.DirectoryName;
                if (directoryName != null)
                {
                    // here it is: rename the file
                    file.MoveTo(Path.Combine(directoryName, Path.GetFileNameWithoutExtension(file.Name)));
                }
            }
        }
        private static void Copy(DirectoryInfo sourceDirectory, DirectoryInfo targetDirectory)
        {
            foreach (var file in sourceDirectory.GetFiles())
            {
                file.CopyTo(Path.Combine(targetDirectory.FullName, file.Name));
            }
            foreach (var directory in sourceDirectory.GetDirectories())
            {
                Copy(directory, targetDirectory.CreateSubdirectory(directory.Name));
            }
        }
    }

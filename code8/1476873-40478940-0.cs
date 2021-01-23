        [ComVisible(true)]
        [Guid("C43E4E36-289C-40C8-9B87-7F79E2B57B0E")] // TODO: replace with your own random GUID
        public class MyResConverter : Microsoft.VisualStudio.TextTemplating.VSHost.BaseCodeGenerator
        {
            public override string GetDefaultExtension()
            {
                // TODO: file extension of the resulting resource file
                return ".res.txt";
            }
            protected override byte[] GenerateCode(string inputFileName, string inputFileContent)
            {
                // TODO: your "compile" step that converts `src.txt` to `res.txt`
                return Encoding.UTF8.GetBytes(inputFileContent.ToUpper());
            }
        }

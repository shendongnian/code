    namespace name
    {
        class TestClass
        {
            public const string ConstBackSlash = "\\"; // The constant back slash
            public string GetApplicationExecutableDirectoryName()
            {
                return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            }
    
            public void Test()
            {
                if (File.Exists(GetApplicationExecutableDirectoryName() + ConstBackSlash + "Temp_File"))
                {
                    MessageBox.Show("File exists");
                }
            }
        }
    }

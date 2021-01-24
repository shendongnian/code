            static void Main(string[] args)
            {
                // Set a variable to the My Documents path.
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    
                var dir = new DirectoryInfo(mydocpath + @"\sample\");
                string msg = "Created by: Johny";
    
                foreach (var file in dir.EnumerateFiles("*.txt"))
                {
                    var streamWriter = file.AppendText(); 
                    streamWriter.Write(msg);
                    streamWriter.Close();
                }
            }

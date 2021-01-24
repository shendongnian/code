        public void Main()
        {
            try
            {
                string dirname = @"C:\Temp\";
                DirectoryInfo directory = new DirectoryInfo(dirname);
                string filepartialname = "test";
                FileInfo[] fileindirectory = directory.GetFiles(filepartialname + "*");
                foreach (FileInfo filename in fileindirectory)
                {
                    if (filename.Extension == "")
                    {
                        //doesn't have an extension                            
                    }
                    else if (!Regex.IsMatch(filename.Name.Replace(filename.Extension, ""), @"^[A-Z|a-z]$"))
                    {
                        //contains more then just test
                    }
                    else
                    {
                        //file is good
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

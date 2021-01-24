    public void DoResume(string output,string address, string username,string password)
        {
            var ftpClient = new ftp(address, username, password);
            // Get the name of all files in output directory
            var localfiles = Directory.GetFiles(output).Select(Path.GetFileName).ToArray();
            /* Get names of uploaded files  */
            var getuploadedfiles = ftpClient.directoryListSimple("/");
            // Get files those are not uploaded
            var diff = localfiles.Except(getuploadedfiles);
            /* Upload Files */
            foreach (var dif in diff)
            {
                foreach (var file in localfiles)
                {
                    if (dif != file) continue;
                    var filetoupload = $"{output}{dif}";
                    ftpClient.upload(file, filetoupload);
                    Console.WriteLine("{0} been uploaded", filetoupload);           
                }
            }
        }

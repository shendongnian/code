    public static String[] FTPListTree(String FtpUri, String User, String Pass) {
    List<String> files = new List<String>();
    Queue<String> folders = new Queue<String>();
    folders.Enqueue(FtpUri);
    while (folders.Count > 0) {
        String fld = folders.Dequeue();
        List<String> newFiles = new List<String>();
        FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(fld);
        ftp.Credentials = new NetworkCredential(User, Pass);
        ftp.UsePassive = false;
        ftp.Method = WebRequestMethods.Ftp.ListDirectory;
        using (StreamReader resp = new StreamReader(ftp.GetResponse().GetResponseStream())) {
            String line = resp.ReadLine();
            while (line != null) {
                newFiles.Add(line.Trim());
                line = resp.ReadLine();
            }
        }
        ftp = (FtpWebRequest)FtpWebRequest.Create(fld);
        ftp.Credentials = new NetworkCredential(User, Pass);
        ftp.UsePassive = false;
        ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        using (StreamReader resp = new StreamReader(ftp.GetResponse().GetResponseStream())) {
            String line = resp.ReadLine();
            while (line != null) {
                if (line.Trim().ToLower().StartsWith("d") || line.Contains(" <DIR> ")) {
                    String dir = newFiles.First(x => line.EndsWith(x));
                    newFiles.Remove(dir);
                    folders.Enqueue(fld + dir + "/");
                }
                line = resp.ReadLine();
            }
        }
        files.AddRange(from f in newFiles select fld + f);
    }
    return files.ToArray();
    }

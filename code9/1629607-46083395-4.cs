    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Text;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string location = @"ftp://localhost";
                byte[] buffer = null;
    
                using (MemoryStream ms = new MemoryStream())
                {
                    FtpWebRequest fwrDownload = (FtpWebRequest)WebRequest.Create($"{location}/test.zip");
                    fwrDownload.Method = WebRequestMethods.Ftp.DownloadFile;
                    fwrDownload.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");
    
                    using (FtpWebResponse response = (FtpWebResponse)fwrDownload.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    {
                        //zipped data stream
                        //https://stackoverflow.com/a/4924357
                        byte[] buf = new byte[1024];
                        int byteCount;
                        do
                        {
                            byteCount = stream.Read(buf, 0, buf.Length);
                            ms.Write(buf, 0, byteCount);
                        } while (byteCount > 0);
                        //ms.Seek(0, SeekOrigin.Begin);
                        buffer = ms.ToArray();
                    }
                }
    
                //include System.IO.Compression AND System.IO.Compression.FileSystem assemblies
                using (MemoryStream ms = new MemoryStream(buffer))
                using (ZipArchive archive = new ZipArchive(ms, ZipArchiveMode.Update))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        FtpWebRequest fwrUpload = (FtpWebRequest)WebRequest.Create($"{location}/{entry.FullName}");
                        fwrUpload.Method = WebRequestMethods.Ftp.UploadFile;
                        fwrUpload.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");
                        
                        byte[] fileContents = null;
                        using (StreamReader sr = new StreamReader(entry.Open()))
                        {
                            fileContents = Encoding.UTF8.GetBytes(sr.ReadToEnd());
                        }
    
                        if (fileContents != null)
                        {
                            fwrUpload.ContentLength = fileContents.Length;
    
                            try
                            {
                                using (Stream requestStream = fwrUpload.GetRequestStream())
                                {
                                    requestStream.Write(fileContents, 0, fileContents.Length);
                                }
                            }
                            catch(WebException e)
                            {
                                string status = ((FtpWebResponse)e.Response).StatusDescription;
                            }
                        }
                    }
                }
            }
        }
    }

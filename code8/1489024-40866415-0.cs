    using ICSharpCode.SharpZipLib.Zip;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    
    namespace MyProject.Controllers
    {
        public class MyController : Controller
        {        
            public ActionResult DownloadFiles()
            {
                var files = SomeFunction();
    			
                // Disable Buffer Output to start the download immediately
                Response.BufferOutput = false;
    
                // Set custom headers to force browser to download the file instad of trying to open it
                Response.ContentType = "application/x-zip-compressed";
                Response.AppendHeader("content-disposition", "attachment; filename=Archive.zip");
    
                byte[] buffer = new byte[4096];
    
                ZipOutputStream zipOutputStream = new ZipOutputStream(Response.OutputStream);
                zipOutputStream.SetLevel(0); // No compression
                zipOutputStream.UseZip64 = UseZip64.Off;
                zipOutputStream.IsStreamOwner = false;
    
                try
                {
                    foreach (var file in files)
                    {
                        using (WebClient wc = new WebClient())
                        {
                            // We open the download stream of the image
                            using (Stream wcStream = wc.OpenRead(file.Url))
                            {
                                ZipEntry entry = new ZipEntry(ZipEntry.CleanName(file.FileName));
                                zipOutputStream.PutNextEntry(entry);
    
                                // As we read the stream, we add its content to the new zip entry
                                int count = wcStream.Read(buffer, 0, buffer.Length);
                                while (count > 0)
                                {
                                    zipOutputStream.Write(buffer, 0, count);
                                    count = wcStream.Read(buffer, 0, buffer.Length);
                                    if (!Response.IsClientConnected)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    zipOutputStream.Finish();
                    zipOutputStream.Close();
                }
                
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
        }
    }

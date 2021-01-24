    using System;
    using System.IO;
    using context = System.Web.HttpContext;
    //Define your application namespace here
    namespace YourApplicationNamespace
    {
        public static class ExceptionLogging
        {
            private static String ErrorlineNo, Errormsg, extype, exurl,  ErrorLocation;
    
            public static void SendErrorToText(Exception ex)
            {
                var line = Environment.NewLine + Environment.NewLine;
    
                ErrorlineNo = ex.StackTrace.ToString();
                Errormsg = ex.Message;
                extype = ex.GetType().ToString();
                exurl = context.Current.Request.Url.ToString();
                ErrorLocation = ex.Message.ToString();
                try
                {
                    //Create a folder named as "ExceptionTextFile" inside your application
                    //Text File Path
                    string filepath = context.Current.Server.MapPath("~/ExceptionTextFile/");  
                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }
                    //Text File Name
                    filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   
                    if (!File.Exists(filepath))
                    {
                        File.Create(filepath).Dispose();
                    }
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        string error = "Log Written Date:" + " " + DateTime.Now.ToString() 
                        + line + "Error Line No :" + " " + ErrorlineNo + line 
                        + "Error Message:" + " " + Errormsg + line + "Exception Type:" + " " 
                        + extype + line + "Error Location :" + " " + ErrorLocation + line 
                        + " Error Page Url:" + " " + exurl + line + line;
                        sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                        sw.WriteLine("-------------------------------------------------------------------------------------");
                        sw.WriteLine(line);
                        sw.WriteLine(error);
                        sw.WriteLine("--------------------------------*End*------------------------------------------");
                        sw.WriteLine(line);
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
        }
    }

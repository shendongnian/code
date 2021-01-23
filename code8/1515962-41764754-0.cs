     public class Log
        {
            
            internal static bool RecordLog(string strSource, string strMethodName, string strStatement)//additional params you think appropriate for your logs
            {
                
              
                    List<string> lstInfo = new List<string>();
    
                    string strProductName = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location.ToString()).ProductName.ToString();
                    string strProductVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location.ToString()).ProductVersion.ToString();
    
                    try
                    {
                        strProductName = FileVersionInfo.GetVersionInfo(Assembly.GetCallingAssembly().Location.ToString()).ProductName.ToString();
                        strProductVersion = FileVersionInfo.GetVersionInfo(Assembly.GetCallingAssembly().Location.ToString()).ProductVersion.ToString();
                    }
                    catch
                    {
                    }
    
                    try
                    {
                        lstInfo.Add("** Date=" + DateTime.Now.ToString("d MMM yy, H:mm:ss") + ", " + strProductName + " v" + strProductVersion);
                        lstInfo.Add("Source=" + strSource + ", Server=" + strServerIP + ""); //add more info in list as per rquirement                  
    
                        bool flag = blnWriteLog("LogFilename",  lstInfo);
                    }
                    catch (Exception objEx)
                    {
                     //exception handling 
                    }
               
                return true;
            }
    
            private static bool blnWriteLog(string strProductName,  List<string> lstInfo)
            {
                string strPath = strGetLogFileName(strProductName);
    			using StreamReader write in the log file received 
                
                return true;
            }
    
            private static string strGetLogFileName(string strFilePrefix)
            {
                //logic to check your file name, if it exists return name else create one 
    
                return strFile;
    
            }
        }

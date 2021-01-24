    private int ExcecuteCommand(string command, string fileName, bool getResult, string timeout = null)
    {
       try
         {
            var secure = new SecureString();
            foreach (char c in txtAdminPassword.Text)
            {
              secure.AppendChar(c);
            }
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.Domain = txtDomainName.Text;
            pProcess.StartInfo.UserName = txtUser.Text;
            pProcess.StartInfo.Password = secure;
            pProcess.StartInfo.FileName = fileName;// AppDomain.CurrentDomain.BaseDirectory + @"PSTools\PsExec.exe"; ;
            //pProcess.StartInfo.Arguments = string.Format(@"\\{0} -i -s -accepteula  ipconfig /all", ipAddress);
            //pProcess.StartInfo.Arguments = string.Format(@"\\{0} -accepteula netstat -ano",ipAddress);
            //pProcess.StartInfo.Arguments = string.Format(@"\\{0} -accepteula -i CheckURLConnectivity", ipAddress);
            //pProcess.StartInfo.Arguments = string.Format(@"\\{0} -accepteula  ping {2}", ipAddress, AppDomain.CurrentDomain.BaseDirectory + @"Installer\CheckURLConnectivity.exe","10.10.10.35");
              //pProcess.StartInfo.Arguments = string.Format(@"\\{0} -accepteula cmd /c type C:\ServiceLog.txt", ipAddress);
             pProcess.StartInfo.Arguments = command;//string.Format(@"\\{0} -accepteula -c -f {1}", compName, AppDomain.CurrentDomain.BaseDirectory + @"Installer\CheckURLConnectivity.exe");
            pProcess.StartInfo.UseShellExecute = false;
            Process.StartInfo.RedirectStandardInput = true;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.RedirectStandardError = true;
            pProcess.StartInfo.CreateNoWindow = true;
            logger.log("Query " + command);
            pProcess.Start();
            if (timeout == null)
               pProcess.WaitForExit();
            else
               pProcess.WaitForExit(Convert.ToInt32(timeout));
    
             string strOutput = string.Empty;
                    
              if (pProcess.HasExited == true && pProcess.ExitCode != 0)
                {
                  string _errorMessage = GetWin32ErrorMessage(pProcess.ExitCode);
                    pProcess.Kill();
                   return pProcess.ExitCode;
                }
                else
                  return 0;
          }
          catch (Exception)
           {
             return -1;
           }
     }

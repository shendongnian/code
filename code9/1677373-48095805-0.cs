    enter code here
    try
                {
                    if (System.IO.File.Exists(@"c:\disk\op.txt") && (new FileInfo(@"c:\disk\op.txt").Length != 0))
                    {
                        System.IO.File.Move(@"c:\disk\op.txt", @"c:\disk\Previous_op_" + DateTime.Now.ToString("dd_MM_yyyy hh mm") + ".txt");
                        log.Info("Previous Output File Successfully Renamed");
                    }
                    // TODO: Add delete logic here
                    log.Info("Input ActionResult - Server " + Server);
                    log.Info("Input ActionResult - Volume " + Volume);
                    log.Info("Input ActionResult - Size " + size);
                    string userID = "dir\\" + Session["Uname"].ToString();
                    string userpassword = Session["Upwd"].ToString();
                    log.Info("username " + userID);               
                    StringBuilder stringBuilder = new StringBuilder();
                    var con = new WSManConnectionInfo();
                    log.Info("Pushing username  in PSCredential- " + userID.ToString().Trim());                
                    con.Credential = new PSCredential(userID.ToString().Trim(), userpassword.ToString().Trim().ToSecureString());
                    Runspace runspace = RunspaceFactory.CreateRunspace(con);
                    runspace.Open();
                    Pipeline pipeline = runspace.CreatePipeline();                
                    pipeline.Commands.AddScript("Set-ExecutionPolicy -Scope Process -ExecutionPolicy Unrestricted");               
                    string _str = @"-Server " + Server + " -Volumeletter " + Volume + ": -deltasize " + size + " -Logfile c:\\disk\\op.txt -username " + userID + " -password " + userpassword;
                    log.Info("Parameter string format- " + _str.Substring(0, _str.IndexOf("-password") + 9));
                    pipeline.Commands.AddScript(@"C:\disk\diskerr.ps1 " + _str.ToString());
                    pipeline.Commands[0].MergeMyResults(PipelineResultTypes.Error, PipelineResultTypes.Output);
                    pipeline.Commands.Add("Out-String");
                    var results = pipeline.Invoke();
                    runspace.Close();
                    runspace.Dispose();
                    foreach (PSObject obj in results)
                    {
                        stringBuilder.AppendLine(obj.ToString());
                        log.Info("Output from powershell: " + obj.ToString());
                    }
                    
                    if (System.IO.File.Exists(@"c:\disk\op.txt") && (new FileInfo(@"c:\disk\op.txt").Length != 0))
                    {
                        fileStream = new FileStream(@"c:\test\op.txt", FileMode.Open, FileAccess.Read);
                        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                        {
                            _consoleOutput = streamReader.ReadToEnd();
                        }
                        _output = Regex.Replace(_consoleOutput, @"\r\n?|\n", "<br />");
                    }
    
                    return Content(_output);                
                }
    
                catch (Exception ex)
                {
                    log.Info("Error stackTrace inside Input ActionResult " + ex.StackTrace.ToString());
                    log.Info("Error Message inside Input ActionResult " + ex.Message.ToString());
                    return View();
                }

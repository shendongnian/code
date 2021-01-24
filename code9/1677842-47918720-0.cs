    catch(Exception Ex)
				{
                    StreamWriter sw = null;
					String Logfile = "C:\ExceptionLog.txt";
                    if (!System.IO.File.Exists(LogFile))
                    {
                        sw = File.CreateText(LogFile);
                        sw.WriteLine(String.Format("Exception\t DateTime"));
                    }
                    else
                    {
                        sw = File.AppendText(@"C:\ExceptionLog.txt");
                    }
                    sw.WriteLine(String.Format("{0}\t {1}", Ex, 
                        DateTime.Now.ToString("MM/dd/yyy HH:mm:ss"));
                    sw.Close();
                }

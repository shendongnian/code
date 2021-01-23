    if (File.Exists(logpath))
            {
                Stream stream = File.Open(logpath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader streamReader = new StreamReader(stream);
                StringBuilder newString = new StringBuilder();
                while (!streamReader.EndOfStream)
                {
                    string str = streamReader.ReadLine();
                    if (str.LastIndexOf("Application engine version 2.0.2016 was initiated") > 0)
                    {
                        str = "Application engine Started";
                    }
                    else if (str.LastIndexOf("Drivers not found") > 0)
                    {
                        str = "Drivers were not found navigate to settings Menu to install them";
                    }
                    newString.AppendLine(str);
                }
                rtbLog.Text = newString.ToString();
                rtbLog.ScrollToCaret();
                streamReader.Close();
                stream.Close();
            }
    ....

    private static string GetExcelFileName(string pid)
        {
            string actualPath = string.Empty;
            try
            {
                Process tool = new Process();
                tool.StartInfo.FileName = @"C:\PrinterPlusPlus\handle.exe";
                tool.StartInfo.Arguments = "/accepteula -p " + pid;
                tool.StartInfo.UseShellExecute = false;
                tool.StartInfo.RedirectStandardOutput = true;
                tool.StartInfo.CreateNoWindow = true;
                tool.Start();
                string outputTool = tool.StandardOutput.ReadToEnd();
                string[] stringSeparators = new string[] { "\r\n" };
                string[] lines = outputTool.Split(stringSeparators, StringSplitOptions.None);
                foreach (string s in lines)
                {
                    if (s.Contains(".xlsx") && !s.Contains("$"))
                    {
                        string[] arrPath = s.Split(new string[] { "File" }, StringSplitOptions.None);
                        string path = string.Empty;
                        if (arrPath.Length > 1)
                        {
                            actualPath = arrPath[1].Trim();
                        }
                    }
                }
            }
            catch
            {
            }
            return actualPath;
        }

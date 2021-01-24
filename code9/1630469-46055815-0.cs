        private void RunQpdfExe(string output)
        {
            string QPDFPath = @"C:\Program Files\qpdf-5.1.2\bin\";
            string newfile = ExportFilePath + ExportFileName + "Lin.pdf";
            try
            {
                // Use ProcessStartInfo class
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.FileName = QPDFPath + "qpdf.exe";
                startInfo.Verb = "runas";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //startInfo.Arguments = " --check " + output;
                startInfo.WorkingDirectory = Path.GetDirectoryName(QPDFPath);
                startInfo.Arguments = " --linearize " + output + " " + newfile;
                
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    if (exeProcess != null)
                    {
                        string op = exeProcess.StandardOutput.ReadToEnd();
                        exeProcess.WaitForExit();
                    }
                }
                
                //Rename the output file back
                File.Delete(output);
                File.Copy(newfile, output);
                File.Delete(newfile);
            }
            catch (Exception)
            {
                // Log error.
            }
        }

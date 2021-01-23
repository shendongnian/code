    public bool ConvertEpsToPdfGSShell(string epsPath, string pdfPath, 
                                       string ghostScriptPath)
        {
            var success = true;
            var epsQual= (char)34 + epsPath + (char)34;
            var sComment = "-q -dNOPAUSE -sDEVICE=pdfwrite -o " + 
            (char)34 + pdfPath + (char)34 + " " + (char)34 + epsPath+ (char)34;
            
            var p = new Process();
            var psi = new ProcessStartInfo {FileName = ghostScriptPath};
            if (File.Exists(psi.FileName) == false)
            {
                throw new Exception("Ghostscript does not exist in the path 
                 given: " + ghostScriptPath);
            }
            psi.CreateNoWindow = true;
            psi.UseShellExecute = true;
            psi.Arguments = sComment;
            p.StartInfo = psi;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit();
            if (p.ExitCode == 0) return success;
            success = false;
            try
            {
                p.Kill();
            }
               
            catch
            {
            }
            finally
            {
                p.Dispose();
            }
            return success;
        }

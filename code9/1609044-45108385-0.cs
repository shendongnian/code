    var vceCopyStartInfo = new StartInfo();
    vceCopyStartInfo.CreateNoWindow = true;
    vceCopyStartInfo.UseShellExecute = false;
    vceCopyStartInfo.WorkingDirectory = "\\Program Files (x86)\\NMS Utilities";
    vceCopyStartInfo.FileName = "vcecopy.exe";
    for (int i = 0; i < files.Count; i++)
    {
        if (files[i].EndsWith(".vce"))
        {
            string fileName = Path.Combine(filePath, files[i]);
            string newFileName = Path.Combine(newPath, files[i]).Replace(".vce", "");
            //some applications need arguments in quotes, try it if this doesn't work.
            vceCopyStartInfo.Arguments = string.Format("{0} {1}.wav", fileName, newFileName));
            using (var vceCopyProcess = Process.Start(vceCopyStartInfo))
            {
                vceCopyProcess.WaitForExit();
                //if vcecopy doesn't exit by itself when it finishes, try WaitForProcessIdle
            }
        }
    }

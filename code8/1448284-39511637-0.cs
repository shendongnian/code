    string fullPath = Path.Combine(path1, "launchinfo.txt");
    if (Directory.Exists(path1))
     {
          if (File.Exists(fullPath))
          {  
             // Call a method to check if the file is in use.         
             if (IsFileLocked(new FileInfo(fullPath)){
                // do something else because you can't delete the file
             } else {
                 File.Delete(fullPath);
                 System.Threading.Thread.Sleep(750);
              }
          }
          using (FileStream fs = File.Create(fullPath))
          {
             Byte[] info = new UTF8Encoding(true).GetBytes("[Connection]\n" + Form1.ipaddress + "\nport=0000\nclient_port=0\n[Details]\n" + Form1.playername);
             fs.Write(info, 0, info.Length);
           }
     }

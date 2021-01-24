     public static string Openfilefrombyte(byte[] myarray, string fileext, string filename)
        {
            Computer myComputer = new Computer();
            string filenamef = myComputer.FileSystem.SpecialDirectories.Temp + @"\" + filename + "." + fileext;
            if (File.Exists(filenamef))
            {
                File.Delete(filenamef);
            }
            //save to file and open
            FileStream myfs = new FileStream(filenamef, FileMode.CreateNew);
            myfs.Write(myarray, 0, myarray.Length);
            myfs.Flush();
            myfs.Close();
            myfs = null;
            Process.Start(filenamef);
            return "OK";
        }

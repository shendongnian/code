    string fileName = Dts.Variables["User::Source_File_And_Path"].Value.ToString();
    string [] fileEntries = Directory.GetFiles(Path.GetFullPath(fileName));
    foreach (string f in fileEntries)
    {
         if (Path.GetExtension(f).ToUpper()==".TXT".ToUpper() && f.StartsWith("Customers_")==true)
         {
            using (StreamWriter w = File.AppendText(f))
                {
                    w.Write("\r\n");
                    w.Close();
                }
         }
    }

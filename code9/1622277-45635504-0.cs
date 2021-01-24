    string[] files = System.IO.Directory.GetFiles(@"J:\", txt_partnum.Text.Substring(0,6) +"*"+".pdf", System.IO.SearchOption.TopDirectoryOnly);
    foreach (string file in files)
    {
       Proccess.Start(file);
    }

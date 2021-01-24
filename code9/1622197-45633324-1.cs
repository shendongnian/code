    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Error.txt";
    
    using (StreamWriter writer = new StreamWriter(filePath, true))
    {
          foreach(var inner in ex.InnerExceptions)
          {
               writer.WriteLine("Message :" + inner.Message + "<br/>" + Environment.NewLine + "StackTrace :" + inner.StackTrace +
               "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
               writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
          }
}

    string Textwritefile = "D:\\Working\\WriteFile.txt";
    string content = "This is testing....";
    
    // Error Code :
    using (FileStream fs = new FileStream(Textwritefile , FileMode.Append, FileAccess.Write))
    {
         fs.SetAccessControl(new FileSecurity(writefilename, AccessControlSections.Access)); 
          using (StreamWriter sw = new StreamWriter(fs))
          {
              sw.WriteLine(content);  //CS.NPS error comes from this line.
          }
    }
    // Fixed code : 
    File.AppendAllText(Textwritefile , content);

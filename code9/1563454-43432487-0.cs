    string yourName = "bob";
    string oldLine;
    string newLine = null;
    StreamReader sr = File.OpenText("C:\\input");
    while ((oldLine = sr.ReadLine()) != null){
        if (!oldLine.Contains(yourName)) newLine += oldLine + Environment.NewLine;  
    }
    sr.Close();
    File.WriteAllText("C:\\output", newLine);

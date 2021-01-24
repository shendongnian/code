    List<string> codeList = File.ReadLines(@"c:\temp\txt1").ToList();
    List<string> nameList = File.ReadLines(@"c:\temp\txt2").ToList();
    
    StringBuilder codeNameBuilder = new StringBuilder();
    
    for (int i = 0; i < codeList.Count; i++)
    {
        codeNameBuilder.AppendFormat("Code = {0} \n Country = {1}", codeList[i], nameList[i]);
    }
    
    System.IO.File.WriteAllText(@"c:\temp\txtOutput.txt", codeNameBuilder.ToString());

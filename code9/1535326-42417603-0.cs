    string[] lineContent = new string[] { };
    string syx = "";
    string cont = "";
    string[] contents = new string[] { };
    string er = "";
        
    string line = "put --------------------,true,10,10";
    lineContent = line.Split(' ');
    syx = lineContent[0];
    cont = lineContent[1];
    contents = cont.Split(',');
        
    if (syx == "put")
    {
      if (contents.Length == 4) // In Debug This Is True
      {
        // Debugger : contents[0] = "-------------------"
        //                    [1] = "true"
        //                    [2] = "10"
        //                    [3] = "10"
        string m = contents[0]; // m = " "
        string r = contents[1]; // r = "true"
        string s = contents[2]; // s = "1"
        string rnd = contents[3]; // rnd = "0"
      }
        
    }

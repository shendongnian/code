    string[] lines = System.IO.File.ReadAllLines("file.txt");
    string result = "";
    for(int i=0;i<lines.length;i++){
        MatchCollection mc = Regex.matches(lines[i], "D;");
        int count = mc.Count;
       result+= string.Format("{0} - {1}\r\n", i+1, count);
    }

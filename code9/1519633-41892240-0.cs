    string[] lines = System.IO.File.ReadAllLines("file.txt");
    
    for(int i=0;i<lines.length;i++){
        MatchCollection mc = Regex.matches(lines[i], "D;");
        int count = mc.Count;
    }

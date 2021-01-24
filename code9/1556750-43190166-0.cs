    StringBuilder sb = new StringBuilder();
    using(StreamReader sr = new StreamReader("Labyrint.txt")){
        sr.ReadLine(); //skip first Line
        while(sr.peek()!=-1){
            sb.AppendLine(sr.ReadLine());
        }
    }
    char[] content = sb.ToString().ToCharArray();
    File.WriteAllText("Labyrint.txt",sb.ToString());

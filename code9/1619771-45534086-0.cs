    Random random = new Random();
    private String TweetString(int Size = 140) {
        var lines = File.ReadLines(@"C:\Path\tweets.csv"); //Note *var*
        var builder = new System.Text.StringBuilder();         
        int randomLine = random.Next(0, lines.Length);
        string line = lines.Skip(randomLine - 1).Take(1).First();
        builder.AppendLine(line);//Add the line to the builder.
        return builder.ToString();
    }

    List<string> solutions = new List<string>();
    List<string> curMoves = new List<string>();
    for (int ccc = 10; ccc <= 34; ccc++)
    {
        solutions = new List<string>();
        curMoves = new List<string>(); 
                
        int count = ccc;
        curMoves.Add("");
        fullMove(count, "", curMoves, solutions);
        Console.WriteLine(ccc + " boxes can be moved in " + solutions.Count + " ways.\r\n");
    }
    StringBuilder sb = new StringBuilder();
    foreach (string s in solutions) sb.Append(s.Length / 4 + " moves:  " + s + "\r\n");
    textBox1.Text = sb.ToString();

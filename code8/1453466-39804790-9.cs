    List<string> solutions = new List<string>();
    List<string> curMoveList = new List<string>();
    for (int ccc = 10; ccc <= 34; ccc++)
    {
        solutions = new List<string>();
        curMoveList = new List<string>(); 
                
        int count = ccc;
        curMoveList.Add("");
        moveBoxes(count, "", curMoveList, solutions);
        Console.WriteLine(ccc + " boxes can be moved in " + solutions.Count + " ways.\r\n");
    }
    StringBuilder sb = new StringBuilder();
    foreach (string s in solutions) sb.Append(s.Length / 4 + " moves:  " + s + "\r\n");
    textBox1.Text = sb.ToString();

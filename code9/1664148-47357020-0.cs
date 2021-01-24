    string people = "Prof. Dr. Bill Gates;bill@microsoft.com;Microsoft Corporation!Dr.Elon Musk; elon @tesla.com; Tesle Inc.!Dr.Mehdi Karakoç; mehdi @tetra.com.tr; Tetra Yazılım!";
    string[] tmp;
    int maxWidth = 0;
    int row;
    List<string[]> everybody = new List<string[]>();
    string[] folks = people.Split('!');
    string[,] matrix;
    foreach (string person in folks)
    {
        tmp = person.Split(';');
        maxWidth = Math.Max(maxWidth, tmp.Length);
        everybody.Add(tmp);
    }
    matrix = new string[everybody.Count, maxWidth];
    row = 0;
    foreach (string[] body in everybody)
    {
        for (int i = 0; i < maxWidth; i++)
        {
            if (i < body.Length)
            {
                matrix[row, i] = body[i];
            }//if this person has enough entries
        }//for each value in person
    }//for each person
    //Result is now a 2 dimensional string array, parsed per value per person.

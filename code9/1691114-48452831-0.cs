    String[,] text = {
            { "Student", "Class", "House" },
            { "Jack", "Math", "Oxford" },
            { "Bender", "Chem", "Trent" } };
        string output = '';
        //string textString;
        for (int i = 0; i < text.GetUpperBound(0); i++)
        {
            output += text[i, 0] + text[i, 1] + text[i, 2] + Environment.NewLine;
        }
        TextBox1.Text = output;

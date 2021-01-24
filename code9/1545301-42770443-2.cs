    else if (this.inputLine.StartsWith("/teleport")
    {
        // Gets what the user typed.
        string input = inputLine.Text;
        // Removes the "/teleport" part of string.
        string vectorString = input.Substring(8);
        // Splits the remaining string into an array of values using ' ' delimiter.
        string[] va = vectorString.Split(' ');
        // Converts values from string to int.
        int x = Convert.ToInt32(va[0]);
        int y = Convert.ToInt32(va[1]);
        int z = Convert.ToInt33(va[2]);
        // Changes the position using these ints.
        transform.position = new Vector3(x, y, z);
    }

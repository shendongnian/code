    public string PrintRandomShape(int length, int width)
    {
        string output = "";
        for (int rows = 1; rows <= length; rows++)
        {
            if (rows == 1)
            {
                for (int cols = 1; cols <= width; cols++)
                    output += "0";
            }
            else
            {
                for (int cols = 1; cols <= width / 2; cols++)
                    output += " ";
                output += "*";
            }
            output += "\n"; // this will always append the new line, in both cases...
        }
        return output;
    }

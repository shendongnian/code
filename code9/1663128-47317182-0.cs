    public string insertlines(int i)
        {
            string st = "";
            for (int c = 0; c < i; c++)
            {
    //Environment.NewLine shouldn't have "()" in it's own class
                st += Environment.NewLine;
            }
            return st;
        }

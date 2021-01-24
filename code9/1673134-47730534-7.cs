    public void toNewFile2()
    {
        using (StreamWriter writetext = new StreamWriter("outputfile2.txt"))
        {
            string newText = (upperString2.ToUpper()).ToString();
            writetext.WriteLine(newText);
        }
    }

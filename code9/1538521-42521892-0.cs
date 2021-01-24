    string t1 = "ABCDEFGXYZ";
    StringBuilder sb = new StringBuilder();
    foreach (char character in t1)
    {
        if (character == 'Z')
        {
            sb.Append('A');
        }
        else
        {
            sb.Append((Char)(Convert.ToUInt16(character) + 1));
        }
    }
    Console.WriteLine(sb.ToString());

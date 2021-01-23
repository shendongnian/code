    public class Bus
    {
        public string[] Val = new string[127];
    }
    j = 0;
    for (int i = 0; i<lines.Length; i++)
    {
        foreach(Bus BusProp in BusList)
        {
            BusProp.Val[j] = line[i + j];
            j =+ 1;
        }
    }

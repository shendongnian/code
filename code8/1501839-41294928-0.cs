    static void Main(string[] args)
    {
        string nullstr = null;
        string teststring = string.Format("{0}", nullstr + (char)('A' + 1));
        Console.WriteLine("After concatenating null string and char = " + teststring);
        Console.WriteLine(setName(10, "_"));
    }
    public static string setName(int count = 0, string prefix = null)
    {
        string str = "";
        for (int i = 0; i < count; i++)
        {
            str += string.Format("{0}", prefix + (char)('A' + i));
        }
        return str;
    }
    // Prints the following:
    //
    // After concatenating null string and char = B
    // _A_B_C_D_E_F_G_H_I_J

    public static void Check(string stringy)
    {
        int gender = 0;
        string[] arrayexample = { "Example One Male", "Example Two Female" };
        var arrayPosition = -1;
        for (var i = 0; i < arrayexample.Length; i++)
        {
            if (arrayexample[i] == stringy)
            {
            arrayPosition = i;
            break;
            }
        }
    }

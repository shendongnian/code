    internal object Repeat(string v1, int v2)
    {
        var str = "";
        for (int i = 0; i < v2; i++)
        {
            str += " " + v1;
        }
        return str.Trim();
   }

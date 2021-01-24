    protected object GetValue(
        object arg, List<string> item, int index)
    {
        if (arg == null)
            //...
        else
            //whatever seems fit for an object that isn't resolved to
            //another overload
    }
    protected string GetValue(
        string arg, List<string> item, int index)
    {
         return arg; //hmmm, how useful is this?
    }
    protected decimal GetValue(
         decimal arg, List<string> item, int index)
    {
         return Convert.ToDecimal(item[index]);
    }
    protected int GetValue(
        int arg, List<string> item, int index)
    {
         return Convert.ToInt32(item[index]);
    }

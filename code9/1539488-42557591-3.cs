    static readonly Func<Stock_On_Hand_File, Nullable<double>>[] Getters = GenerateGetters();
    static Func<Stock_On_Hand_File, Nullable<double>>[] GenerateGetters()
    {
        var getters = new Func<Stock_On_Hand_File, Nullable<double>>[52];
        for (int i = 0; i < getters.Length; i++)
        {
            var getter = typeof(Stock_On_Hand_File).GetProperty("WK_" + (i + 1).ToString("D3")).GetGetMethod();
            getters[i] = (Func<Stock_On_Hand_File, Nullable<double>>)Delegate.CreateDelegate(typeof(Func<Stock_On_Hand_File, Nullable<double>>), getter);
        }
        return getters;
    }

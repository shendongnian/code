    protected string this[enu.QS index]
    {
        get
        {
            try
            {
                return l_QSItems[(int)index].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        set
        {
            ValidateStringSize(index.ToString(), value);
            l_QSItems[(int)index] = value;
        }
    }

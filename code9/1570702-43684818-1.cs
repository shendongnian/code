    protected string this[enu.QS index]
    {
        get
        {
            try
            {
                return l_QSItems[index].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        set
        {
            ValidateStringSize(index.ToString(), value);
            l_QSItems[index] = value;
        }
    }

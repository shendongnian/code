    public string this[string strItemType]
    {
        get
        {
            try
            {
                return myContext.ContextString[strItemType];
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        set
        {
            try
            {
                myContext.ContextString[strItemType] = value;
            }
            catch (Exception ex) { }
        }
    }

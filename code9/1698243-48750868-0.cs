    public string this[string strItemType]
    {
        set
        {
            try
            {
                SetCtxString(strItemType, value);
            }
            catch (Exception ex) { }
        }
    }

    public bool GetVisible(object value)
    {
        if (Convert.ToDateTime(value) <= DateTime.Now)
        {
            return true;
            //Or this
            //return value.ToString() == "Visible";
        }
        return false;
    }

    public bool GetVisible(object value)
    {
        if (Convert.ToDateTime(value) < DateTime.Now)
        {
            return value.ToString() == "Visible";
        }
        return false;
    }

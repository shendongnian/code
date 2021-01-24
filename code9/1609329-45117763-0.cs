    public string GroupDate
    {
        get 
        {
            if(YourDateProperty.Date == DateTime.Now.Date)
                return "Today";
            else
                return YourDateProperty.ToString("dd/MM-yyyy");
        }
    }

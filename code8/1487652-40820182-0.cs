    public void UpdateSetting(string setting, Enum value, string text = "")
    {
    	var intValue = Convert.ToInt32(value);
    
    	lock (locker)
    	{
    		db2.Execute("UPDATE Setting SET Value = ?, Text = ?" +
    					  " WHERE SettingType = ?", intValue, text, setting);
    	}
    }

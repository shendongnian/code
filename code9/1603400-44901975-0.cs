    public void Save(SettingsEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException();
        var existing = Settings.Where(se => se.UserID == entity.UserID && se.ApplicationName == entity.ApplicationName && se.SettingKey == entity.SettingKey).ToList();
        if (existing.Count > 0)
            existing.ForEach(f => f.SettingValue = entity.SettingValue);
        else
            Settings.Add(entity);
    }

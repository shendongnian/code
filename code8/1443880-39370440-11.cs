    private void ResetSettings(TabPage tabPage)
    {
        foreach (Control c in tabPage.Controls)
        {
            foreach (Binding b in c.DataBindings)
            {
                if (b.DataSource is ApplicationSettingsBase)
                {
                    var settings = (ApplicationSettingsBase)b.DataSource;
                    var key = b.BindingMemberInfo.BindingField;
                    var property = settings.Properties[key];
                    var defaultValue = property.DefaultValue;
                    var type = property.PropertyType;
                    var value = TypeDescriptor.GetConverter(type).ConvertFrom(defaultValue);
                    settings[key] = value;
                    //You can also save settings
                    settings.Save();
                }
            }
        }
    }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var p = Server.MapPath("~/Web.user.config");
            if (File.Exists(p))
            {
                var fileMap = new ConfigurationFileMap(p); //Path to your config file
                var userConfig = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
                var globalConfig = WebConfigurationManager.OpenWebConfiguration("~/");
                var globalGroups = globalConfig.SectionGroups.Cast<ConfigurationSectionGroup>().ToList();
                CopySections(userConfig.Sections.Cast<ConfigurationSection>(), globalConfig.Sections.Cast<ConfigurationSection>());
                foreach (ConfigurationSectionGroup userGroup in userConfig.SectionGroups)
                {
                    var globalGroup =  globalGroups.SingleOrDefault(g => g.SectionGroupName == userGroup.SectionGroupName);
                    if (globalGroup != null)
                    {
                        CopySections(userGroup.Sections.Cast<ConfigurationSection>(), globalGroup.Sections.Cast<ConfigurationSection>());
                    }
                }
                globalConfig.Save();
            }
        }
        private void CopySections(IEnumerable<ConfigurationSection> source, IEnumerable<ConfigurationSection> target)
        {
            foreach (var sourceSection in source)
            {
                var targetSection = target.SingleOrDefault(s => s.SectionInformation.SectionName == sourceSection.SectionInformation.SectionName);
                if (targetSection != null)
                {
                    var targetAppSettings = targetSection as AppSettingsSection;
                    if (targetAppSettings != null)
                    {
                        var sourceAppSettings = (AppSettingsSection) sourceSection;
                        foreach (KeyValueConfigurationElement keyValue in sourceAppSettings.Settings)
                        {
                            var targetSettings = targetAppSettings.Settings;
                            if (targetSettings.AllKeys.Any(k => k == keyValue.Key))
                            {
                                targetSettings.Remove(keyValue.Key);
                            }
                            targetSettings.Add(keyValue);
                        }
                    }
                    var targetClientSettings = targetSection as ClientSettingsSection;
                    if (targetClientSettings != null)
                    {
                        var sourceClientSettings = (ClientSettingsSection) sourceSection;
                        foreach (SettingElement keyValue in sourceClientSettings.Settings)
                        {
                            var targetSettings = targetClientSettings.Settings;
                            var existingSetting = targetSettings.Cast<SettingElement>().SingleOrDefault(e => e.Name == keyValue.Name);
                            if (existingSetting != null)
                            {
                                existingSetting.Value = keyValue.Value;
                            }
                        }
                    }
                }
            }
        }

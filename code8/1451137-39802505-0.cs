     if (section != null || !section.SectionInformation.IsProtected)
    {
       section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
       config.Save();
    }

     if (section != null || !section.SectionInformation.IsProtected)
        {
           section.SectionInformation.ProtectSection("RsaProtectionConfigurationProvider");
           config.Save();
        }

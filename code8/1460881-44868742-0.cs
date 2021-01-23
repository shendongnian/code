    /// <summary>
    /// Encrypts one or more sections of the web.config using the provided provider.
    /// </summary>
    /// <param name="protectionProvider">
    /// Protection provider to use:
    /// RsaProtectedConfigurationProvider or DPAPIProtectedConfigurationProvider.
    /// </param>
    /// <param name="sectionsToEncrypt">Array of section names to encrypt</param>
    /// <returns>
    /// On success returns true
    /// On failure returns false
    /// </returns>
    public static bool EncryptConfigurationSections(
    	string protectionProvider, 
    	params string[] sectionsToEncrypt
    ) {
    	bool isOK = true;
    	List<string> SUPPORTED_PROVIDERS = new List<string>() { 
    		"RsaProtectedConfigurationProvider", 
    		"DPAPIProtectedConfigurationProvider" 
    	};
    
    	if (!SUPPORTED_PROVIDERS.Contains(protectionProvider)) {
    		throw new ArgumentException("Provided provider is not supported.", "protectionProvider");
    	}
    
    	try {
    		Configuration webConfiguration = null;
    		bool saveRequired = false;
    		// OpenWebConfiguration call will find the web.config file, we only need the directory (~)
    		webConfiguration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
    
    		// Protect all specified sections 
    		// ... Do all that apply in one go so we only have the hit of saving once
    		foreach (string sectionToEncrypt in sectionsToEncrypt) {
    			ConfigurationSection configSection = webConfiguration.GetSection(sectionToEncrypt);
    
    			// No point encrypting if it's already been done
    			if (configSection != null && !configSection.SectionInformation.IsProtected) {
    				saveRequired = true;
    				configSection.SectionInformation.ProtectSection(protectionProvider);
    				configSection.SectionInformation.ForceSave = true;
    			}
    		}
    
    		if (saveRequired) {
    			// Only save if there's a section which was not protected
    			// ... again, no point taking the hit if we don't need to
    			webConfiguration.Save(ConfigurationSaveMode.Modified);
    		}
    	}
    	catch (Exception e) {
    		isOK = false;
    	}
    
    	return isOK;
    
    } // EncryptConfigurationSections
    

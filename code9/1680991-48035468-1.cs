     private static string GetHostname()
        {
            // Get the Site name 
            string siteName = HostingEnvironment.SiteName; 
            // Get the sites section from the AppPool.config
            Microsoft.Web.Administration.ConfigurationSection sitesSection =
                Microsoft.Web.Administration.WebConfigurationManager.GetSection(null, null,
                    "system.applicationHost/sites");
            foreach (Microsoft.Web.Administration.ConfigurationElement site in sitesSection.GetCollection())
            {
                // Find the right Site
                if (string.Equals((string)site["name"], siteName, StringComparison.OrdinalIgnoreCase))
                { 
                    // For each binding see if they are http based and return the port and protocol
                    foreach (Microsoft.Web.Administration.ConfigurationElement binding in site.GetCollection("bindings"))
                    {
                        var bindingInfo = (string)binding["bindingInformation"]; 
                        return bindingInfo.Split(':')[2]; 
                    }
                }
            }
            return null;
        }

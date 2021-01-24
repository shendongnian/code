        /// <summary>
        /// Create a new web site on the iis host.
        /// </summary>
        /// <param name="iisHostPath">The iis host path.</param>
        /// <param name="websiteID">The unique web site id.</param>
        /// <param name="websiteName">The name of the web site.</param>
        /// <param name="physicalPath">The physical path to the root directory.</param>
        /// <returns>True if the web site was created else false.</returns>
        /// <example>
        /// iisHostPath : [servername]/[service] : localhost/W3SVC
        /// websiteID : [number] : 454354
        /// </example>
        /// <remarks>
        /// <para>iisHostPath : [servername]/[service] : localhost/W3SVC</para>
        /// <para>websiteID : [number] : 454354</para>
        /// </remarks>
        public virtual bool CreateWebSite(string iisHostPath,
            string websiteID, string websiteName, string physicalPath)
        {
            // Validate the inputs.
            if (String.IsNullOrEmpty(iisHostPath))
                throw new System.ArgumentNullException("IIS path can not be null.",
                    new System.Exception("A valid IIS path should be specified."));
            // Validate the inputs.
            if (String.IsNullOrEmpty(websiteID))
                throw new System.ArgumentNullException("Web site id can not be null.",
                    new System.Exception("A valid web site id should be specified."));
            // Validate the inputs.
            if (String.IsNullOrEmpty(websiteName))
                throw new System.ArgumentNullException("Web site name can not be null.",
                    new System.Exception("A valid web site name should be specified."));
            // Validate the inputs.
            if (String.IsNullOrEmpty(physicalPath))
                throw new System.ArgumentNullException("Physical can not be null.",
                    new System.Exception("A valid physical path should be specified."));
            // Create a new directory entry
            // instance to the iis machine.
            DirectoryEntry localMachine = new DirectoryEntry(
                "IIS://" + iisHostPath);
            // Add the iis web site
            // to the iis collection.
            DirectoryEntry siteName = localMachine.Children.Add(websiteID, "IIsWebServer");
            // Assign the web site properties.
            siteName.Properties["ServerComment"][0] = websiteName;
            siteName.CommitChanges();
            // Commit the changes for the account.
            siteName.CommitChanges();
            // Add the iis web site
            // to the iis collection.
            DirectoryEntry rootName = siteName.Children.Add("Root", "IIsWebVirtualDir");
            // Assign the web site properties.
            rootName.Properties["Path"][0] = physicalPath;
            rootName.Properties["AccessScript"][0] = true;
            // Commit the changes for the account.
            rootName.CommitChanges();
            // Close the connections.
            rootName.Close();
            siteName.Close();
            localMachine.Close();
            // Return success.
            return true;
        }

        /// <summary>
        /// Create a new virtual directory on the iis host.
        /// </summary>
        /// <param name="iisHostPath">The iis host path.</param>
        /// <param name="physicalPath">The physical path to the directory.</param>
        /// <param name="virtualDirectoryName">The virtual directory name.</param>
        /// <param name="defaultDocument">The defualt document to set.</param>
        /// <returns>True if the virtual directory was created else false.</returns>
        /// <example>
        /// iisHostPath : [servername]/[service]/[websiteID]/[Root] : localhost/W3SVC/1/Root
        /// defaultDocument : [document] : default.aspx
        /// </example>
        /// <remarks>
        /// <para>iisHostPath : [servername]/[service]/[websiteID]/[Root] : localhost/W3SVC/1/Root</para>
        /// <para>defaultDocument : [document] : default.aspx</para>
        /// </remarks>
        public virtual bool CreateVirtualDirectory(string iisHostPath, string physicalPath,
            string virtualDirectoryName, string defaultDocument)
        {
            // Validate the inputs.
            if (String.IsNullOrEmpty(iisHostPath))
                throw new System.ArgumentNullException("IIS path can not be null.",
                    new System.Exception("A valid IIS path should be specified."));
            // Validate the inputs.
            if (String.IsNullOrEmpty(physicalPath))
                throw new System.ArgumentNullException("Physical can not be null.",
                    new System.Exception("A valid physical path should be specified."));
            // Validate the inputs.
            if (String.IsNullOrEmpty(virtualDirectoryName))
                throw new System.ArgumentNullException("Virtual directory name can not be null.",
                    new System.Exception("A valid virtual directory name should be specified."));
            // Validate the inputs.
            if (String.IsNullOrEmpty(defaultDocument))
                throw new System.ArgumentNullException("Default document can not be null.",
                    new System.Exception("A valid default document should be specified."));
            // Create a new directory entry
            // instance to the iis machine.
            DirectoryEntry localMachine = new DirectoryEntry(
                "IIS://" + iisHostPath);
            // Add the iis virtual directory
            // to the iis collection.
            DirectoryEntry virtName = localMachine.Children.Add(virtualDirectoryName, "IIsWebVirtualDir");
            // Commit the changes for the account.
            virtName.CommitChanges();
            // Assign default properties.
            virtName.Properties["Path"][0] = physicalPath;
            virtName.Properties["DefaultDoc"][0] = defaultDocument;
            virtName.Properties["AccessScript"][0] = true;
            // These properties are necessary for an application to be created.
            virtName.Properties["AppFriendlyName"][0] = virtualDirectoryName;
            virtName.Properties["AppIsolated"][0] = "1";
            virtName.Properties["AppRoot"][0] = "/LM/" + iisHostPath;
            // Commit the changes for the account.
            virtName.CommitChanges();
            // Close the connections.
            virtName.Close();
            localMachine.Close();
            // Return success.
            return true;
        }

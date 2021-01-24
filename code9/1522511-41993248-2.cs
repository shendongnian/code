        /// <summary>
        /// Set a port number to a web site on the iis host.
        /// </summary>
        /// <param name="iisHostPath">The iis host path.</param>
        /// <param name="portNumber">The port number.</param>
        /// <returns>True if the port number was assigned else false.</returns>
        /// <example>
        /// iisHostPath : [servername]/[service]/[websiteID] : localhost/W3SVC/1
        /// </example>
        /// <remarks>
        /// <para>iisHostPath : [servername]/[service]/[websiteID] : localhost/W3SVC/1</para>
        /// </remarks>
        public virtual bool SetWebSitePortNumber(string iisHostPath, int portNumber)
        {
            // Validate the inputs.
            if (String.IsNullOrEmpty(iisHostPath))
                throw new System.ArgumentNullException("IIS path can not be null.",
                    new System.Exception("A valid IIS path should be specified."));
            // Validate the inputs.
            if (portNumber < 1)
                throw new System.ArgumentNullException("Port number not valid.",
                    new System.Exception("The port number must be greater than zero."));
            // Create a new directory entry
            // instance to the iis machine.
            DirectoryEntry localMachine = new DirectoryEntry(
                "IIS://" + iisHostPath);
            // Set the web site port number.
            localMachine.Properties["ServerBindings"][0] = ":" + portNumber + ":";
            // Commit the changes for the account.
            localMachine.CommitChanges();
            // Close the connections.
            localMachine.Close();
            // Return success.
            return true;
        }

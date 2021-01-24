    private bool CheckIfItemIsExternal(string itemPath)
        {
            List<SvnStatusEventArgs> svnStates = new List<SvnStatusEventArgs>();
            using (SvnClient svnClient = new SvnClient())
            {
                // use throw on error to avoid exception in case the item is not versioned
                // use retrieve all entries option to secure that all status properties are retrieved
                SvnStatusArgs svnStatusArgs = new SvnStatusArgs()
                {
                    ThrowOnError = false,
                    RetrieveAllEntries = true,
                };
                Collection<SvnStatusEventArgs> svnStatusResults;
                if (svnClient.GetStatus(itemPath, svnStatusArgs, out svnStatusResults))
                    svnStates = new List<SvnStatusEventArgs>(svnStatusResults);
            }
            foreach (var status in svnStates)
            {
                if (status.IsFileExternal)
                    return true;
                else if (status.NodeKind == SvnNodeKind.Directory)
                {
                    string parentDirectory = Directory.GetParent(itemPath).ToString();
                    List<SvnPropertyListEventArgs> svnProperties = RetrieveSvnProperties(parentDirectory);
                    foreach (var itemProperties in svnProperties)
                    {
                        foreach (var property in itemProperties.Properties)
                        {
                            if (property.Key == "svn:externals" && property.StringValue.Contains(new DirectoryInfo(itemPath).Name))
                                return true;
                        }
                    }
                }
            }
            return false;
        }

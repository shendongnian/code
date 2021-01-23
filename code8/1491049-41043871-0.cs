                    using (DirectoryEntry entry = directorySearcher.FindOne()?.GetDirectoryEntry())
                    {
                        if (entry == null)
                        {
                            //report error
                        }
                        entry.RefreshCache(new string[] { "allowedAttributesEffective" });
                        if (entry.Properties["allowedAttributesEffective"].Value != null)
                        {
                            if (this.properties == null || this.properties.All(property => entry.Properties["allowedAttributesEffective"].Contains(property)))
                            {
                                //sufficient rights
                            }
                            else
                            {
                                //insufficient rights
                            }
                        }
                        else
                        {
                            //not possible to check attribute "allowedAttributesEffective", it is missing or you have insufficient rights to read it
                        }
                    }

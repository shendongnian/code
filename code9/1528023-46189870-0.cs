    string newPartitionName = Convert.ToString(properties.ListItem["Title"]); // current item                   
                        using (SPSite site = new SPSite(RBSSiteURL))
                        {
                            using (SPWeb web = site.OpenWeb())
                            {
                                SPSecurity.RunWithElevatedPrivileges(delegate
                                {
                                    web.AllowUnsafeUpdates = true;
                                    SPList spList = web.Lists["Room List"];
                                    SPFieldMultiChoice spChoiceField = (SPFieldMultiChoice)spList.Fields["Select Partitions"];
                                    spChoiceField.AddChoice(newPartitionName);
                                    spChoiceField.Update();
                                    spList.Update();
                                    web.AllowUnsafeUpdates = false;
                                });
                            }
                        }

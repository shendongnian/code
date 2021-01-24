            Outlook.Results advancedSearchResults = advancedSearch.Results;
            if (advancedSearchResults.Count > 0)
            {
                if (HostMajorVersion > 10)
                {
                    object folder = advancedSearch.GetType().InvokeMember("Save", 
                                       System.Reflection.BindingFlags.Instance |
                                       System.Reflection.BindingFlags.InvokeMethod | 
                                       System.Reflection.BindingFlags.Public,
                                       null, advancedSearch, 
                                       new object[] { advancedSearchTag });
 
                }
                else
                {
                    strBuilder = new System.Text.StringBuilder();
                    strBuilder.AppendLine("Number of items found: " +
                              advancedSearchResults.Count.ToString());                            
                    for (int i = 1; i < = advancedSearchResults.Count; i++)
                    {                                
                        resultItem = advancedSearchResults[i] 
                                          as Outlook.MailItem;
                        if (resultItem != null)
                        {
                            strBuilder.Append("#" + i.ToString());
                            strBuilder.Append(" Subject: " + resultItem.Subject);
                            strBuilder.Append(" \t To: " + resultItem.To);
                            strBuilder.AppendLine(" \t Importance: " + 
                                               resultItem.Importance.ToString());
                            Marshal.ReleaseComObject(resultItem);
                        }
                    }
                    if (strBuilder.Length > 0)
                        System.Diagnostics.Debug.WriteLine(strBuilder.ToString());   
                    else
                        System.Diagnostics.Debug.WriteLine(
                                                "There are no Mail items found.");
                 }
            }
            else
            {
                 System.Diagnostics.Debug.WriteLine("There are no items found.");
            }

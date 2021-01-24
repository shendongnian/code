     string filter = "(&(objectClass=*)(msExchRecipientDisplayType=7))";
     //Assembly System.DirectoryServices.dll
     DirectorySearcher search = new DirectorySearcher(filter);
     List<AttendeeInfo> rooms = new List<AttendeeInfo>();  
     foreach (SearchResult result in search.FindAll())
                {
                    ResultPropertyCollection r = result.Properties;
                    DirectoryEntry entry = result.GetDirectoryEntry();
                    // entry.Properties["displayName"].Value.ToString() will bring the room name
                    rooms.Add(new AttendeeInfo(entry.Properties["mail"].Value.ToString().Trim()));                 
                }

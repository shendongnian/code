    public override void ItemAdding(SPItemEventProperties properties)
    {
         long validFileSize  = 1000000;//1MB;
         long currentFileSize;
         if (properties.ListItem == null)
         {
                 using (SPWeb web = properties.OpenWeb())
                 {                   
    				 if (properties.ListTitle.ToLower() == "myLibrary")
    				 {						 
    					  currentFileSize = long.Parse(properties.AfterProperties["vti_filesize"].ToString());
    					  if (currentFileSize > validFileSize)
    					  {
    							return false;
    					  }
    				}                 
              }
        }
        else if (properties.ListItem.ParentList.Title.ToLower() == "myLibrary")
        {         
                    currentFileSize = properties.ListItem.File.TotalLength;
                    if (currentFileSize > validFileSize)
                    {
                          return false;
                    }
             
        }
        return true;
    } 

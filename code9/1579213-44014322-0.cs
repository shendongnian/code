            internal static Folder GetFolderFromPath(ExchangeService service,String MailboxName,String FolderPath)
    {
        FolderId folderid = new  FolderId(WellKnownFolderName.MsgFolderRoot,MailboxName);   
        Folder tfTargetFolder = Folder.Bind(service,folderid);
        PropertySet psPropset = new PropertySet(BasePropertySet.FirstClassProperties);
        String[] fldArray = FolderPath.Split('\\'); 
        for (Int32 lint = 1; lint < fldArray.Length; lint++) { 
            FolderView fvFolderView = new FolderView(1);
            fvFolderView.PropertySet = psPropset;
            SearchFilter  SfSearchFilter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName,fldArray[lint]); 
            FindFoldersResults findFolderResults = service.FindFolders(tfTargetFolder.Id,SfSearchFilter,fvFolderView); 
            if (findFolderResults.TotalCount > 0){ 
            foreach(Folder folder in findFolderResults.Folders){ 
                tfTargetFolder = folder;                
                } 
            } 
            else{ 
                tfTargetFolder = null;  
                break;  
            }     
        }
        if (tfTargetFolder != null)
        {
            return tfTargetFolder;
        }
        else
        {
            throw new Exception("Folder Not found");
        }
    }

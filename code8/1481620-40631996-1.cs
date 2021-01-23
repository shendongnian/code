    public static void CreateDocumentSet(List list, string docSetName)
    {
            var ctx = list.Context;
            if (!list.IsObjectPropertyInstantiated("RootFolder"))
            {
                ctx.Load(list.RootFolder);
                ctx.ExecuteQuery();
            }
            
            var itemInfo = new ListItemCreationInformation();
            itemInfo.UnderlyingObjectType = FileSystemObjectType.Folder;
            itemInfo.LeafName = docSetName;
            itemInfo.FolderUrl = list.RootFolder.ServerRelativeUrl;
            var item = list.AddItem(itemInfo);
            item["ContentTypeId"] = "0x0120D520";
            item["HTML_x0020_File_x0020_Type"] = "SharePoint.DocumentSet";
            item.Update();
            ctx.ExecuteQuery();
    }

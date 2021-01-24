    public ActionResult DownloadFile(string fileName, Guid guid)
            {
                Item item = db.Items.FirstOrDefault(x => x.ItemGUID == guid);
    
                if (item == null)
                    return null;
    
                List <SecurityMask> accessList = GetAccessRightsForItem(item.item_id,
                                                    ActiveDirectory.GetUserSID(User.Identity.Name));
    
                bool hasAccess = false || (accessList.Contains(SecurityMask.View) || accessList.Contains(SecurityMask.Modify));
                
                string filePath = Path.GetFullPath(Path.Combine(HttpRuntime.AppDomainAppPath,
                                            "Files\\Items", guid.ToString(), fileName));
    
                string mimeType = MimeMapping.GetMimeMapping(filePath);
    
                bool fileExists = System.IO.File.Exists(filePath);
    
                if (hasAccess && fileExists)
                {
                    return File(System.IO.File.ReadAllBytes(filePath), mimeType);
                }
                return null;
            }

     var  query = new QueryExpression("organization")
                    {
                        ColumnSet = new ColumnSet("blockedattachments", "maxuploadfilesize")
                    };
                    var record = service.RetrieveMultiple(query).Entities.FirstOrDefault();
        
                    if (record != null)
                    {
                        var blockedAttachments = record.GetAttributeValue<string>("blockedattachments");
                        var maxAttachmentSize = record.GetAttributeValue<int>("maxuploadfilesize");
                    }

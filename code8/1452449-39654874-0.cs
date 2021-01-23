    var query = new QueryExpression("organization")
              {
                    ColumnSet = new ColumnSet("blockedattachments", "maxuploadfilesize")
               };
               EntityCollection orgCollection = _service.RetrieveMultiple(query);
               if (orgCollection.Entities.Count > 0)
               {
               Entity org = orgCollection.Entities.First();
               string blockedattachments = org.GetAttributeValue<string>("blockedattachments");
               int numberMaxUploadFileSize = org.GetAttributeValue<int>("maxuploadfilesize");
               }

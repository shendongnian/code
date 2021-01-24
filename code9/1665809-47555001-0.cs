    public string GetContent(string pageName, string propertyName)
        {
            string content = string.Empty;
            try
            {
                log.Info("GetContent Method is called for getting property value!!!!!");
                IContentTypeRepository contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
                IEnumerable<ContentType> allPageTypes = contentTypeRepository.List().OfType<PageType>();
                IContentModelUsage contentModelUsage = ServiceLocator.Current.GetInstance<IContentModelUsage>();
                IList<ContentUsage> pageInstanceCollection = new List<ContentUsage>();
                foreach (ContentType item in allPageTypes)
                {
                    IList<ContentUsage> pageInstance = contentModelUsage.ListContentOfContentType(item);
                    foreach (ContentUsage i in pageInstance)
                    {
                        pageInstanceCollection.Add(i);
                    }
                }
                IEnumerable<ContentUsage> currentpage = pageInstanceCollection.Where(x => x.Name.ToLower() == pageName.ToLower());
                int Id = currentpage.First().ContentLink.ID;
                PageReference pagereference = new PageReference(Id);
                IContentRepository contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
                PageData pageData = contentRepository.Get<PageData>(pagereference);
                content = pageData.GetPropertyValue(propertyName);
               
            }
            catch(Exception exception)
            {
                string errorMessage = string.Format("Error in Content Retrieval : {0}", exception.Message);
                log.Error(errorMessage, exception);
            }
            return content;
        }

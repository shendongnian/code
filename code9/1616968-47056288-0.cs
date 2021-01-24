    public void DeletePageNativeAPI(string pageTitleToDelete)
            {
                PageManager pageManager = PageManager.GetManager();
                PageData page = pageManager.GetPageDataList().Where(pD => (pD.NavigationNode.Title == pageTitleToDelete && pD.Status == ContentLifecycleStatus.Live)).FirstOrDefault();
    
                if (page != null)
                {
                    pageManager.Delete(page);
                    pageManager.SaveChanges();
                }
            }

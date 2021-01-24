    public void SelectHomepageSearchPanelLink(string linkText)
        {
            var searchPanelLinks = _driver.FindElements(HomepageResponsiveElements.HomepageSearchPanelLinks);
    
            foreach (var searchPanelLink in searchPanelLinks)
            {
                if (searchPanelLink.Text == linkText)
                {
                   var linkToClick = searchPanelLink;
                   break;
                }
                else
                {
                    throw new Exception($"{linkText} link not found by the responsive homepage search panel");
                }
            }
        	linkToClick.Click();
    } 

        private string GetiFrameID()
        {
            return _pageManager.BrowserDriver
                                            .FindElement(By.Id(CrmCommon.contentpanel))
                                            .FindElements(By.TagName("iframe"))
                                            .FirstOrDefault(x => x.GetAttribute("style")
                                            .Contains("visible"))
                                            .GetAttribute("id");
        }

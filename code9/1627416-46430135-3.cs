    public App()
    {
       ...
       this.ModalPushed += OnModalPushed;
       this.ModalPopped += OnModalPopped;
    }
    //keep track of any modals presented
    private readonly Stack<Page> ModalPages = new Stack<Page>();  
    void OnModalPushed(object sender, ModalPushedEventArgs e)
    {
        ModalPages.Push(e.Modal);
        PageService.CurrentPage = FindCurrentPage();
    }
    void OnModalPopped(object sender, ModalPoppedEventArgs e)
    {
        ModalPages.Pop();
        PageService.CurrentPage = FindCurrentPage();
    }
    public Page FindCurrentPage()
    {
        //If there is a Modal present, start there, or else start in the MainPage
        Page root = ModalPages.Count > 0 ? ModalPages.Peek() : this.MainPage;
        var tabbedPage = root as TabbedPage;
        if (tabbedPage != null)
        {
            var currentTab = tabbedPage.CurrentPage;
            var navPage = currentTab as NavigationPage;
            if (navPage != null)
            {
                return navPage.CurrentPage;
            }
            else
            {
                return currentTab;
            }
        }
        else
        {
            var navPage = root as NavigationPage;
            if (navPage != null)
            {
                return navPage.CurrentPage;
            }
            return root;
        }
    }

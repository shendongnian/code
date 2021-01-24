        protected virtual void SetupSideMenu()
        {
            var leftSideMenu = ResolveSideMenu(MvxPanelEnum.Left);
            var rightSideMenu = ResolveSideMenu(MvxPanelEnum.Right);
            if (leftSideMenu == null && rightSideMenu == null)
            {
                Mvx.Trace(MvxTraceLevel.Warning, $"No sidemenu found. To use a sidemenu decorate the viewcontroller class with the 'MvxPanelPresentationAttribute' class and set the panel to 'Left' or 'Right'.");
                AttachNavigationController();
                return;
            }
    
            // ...
        }
    

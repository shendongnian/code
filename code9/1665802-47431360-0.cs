      public bool DoBack
            {
                get
                {
                    MasterDetailPage mainPage = App.Current.MainPage as MasterDetailPage;
    
                    if (mainPage != null)
                    {
                        bool canDoBack = mainPage.Detail.Navigation.NavigationStack.Count > 1 || mainPage.IsPresented;
    
                        // we are on a top level page and the Master menu is NOT showing
                        if (!canDoBack)
                        {
                            // don't exit the app just show Dashboard
                            //mainPage.IsPresented = true;
    
                            Type page = typeof(DrawerPage);
    
                            mainPage.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

    public ListView CurrentTab
    {
        get
        {
             return (ListView)this.Dispatcher.Invoke(
              new Func<ListView>(() => 
              { 
                  ListView listView = null;
                  int currentTab = tabControl.SelectedIndex;
                    switch (currentTab)
                    {
                        case 0:
                            listView = new ListView();
                            listView = list_1;
                            break;
                        case 1:
                            listView = list_2;
                            break;
                        case 2:
                            listView = list_3;
                            break;
                    }
                    return listView;
              }));
        }
    }

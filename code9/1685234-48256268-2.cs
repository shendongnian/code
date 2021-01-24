        internal sealed class MenuViewModel
        {
           public MenuViewModel()
           {
           }
           public MenuViewModel(MenuModel wModel)
           {
               if (wModel == null) { return; }
               MenuModelData = wModel;
           }
           private MenuModel _MenuModelData;
           public MenuModel MenuModelData
           {
               get
               {
                   if (_MenuModelData == null) { _MenuModelData = new MenuModel(); }
                   return _MenuModelData;
               }
               set
               {
                   MenuModelData = value;
               }
           }
       }

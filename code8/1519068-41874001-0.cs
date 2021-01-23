    public class MenuItem 
    {
      MenuCardViewModel parent;
      //// pass parent to menuItem
      public MenuItem(MenuCardViewModel parent)
      {
        this.parent=parent;
      }
    
       public ICommand MenuItemClickCommand
       {
           get
            {
                return MvxCommand(() -> this.parent.DoMenuItemClickCommand(this));
            }
       }
    }

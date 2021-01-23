    public class MenuContainer
    {
         public ICollection<MenuComponent> Menus { get; }
    }
    public class MenuComponent
    {
         ....
         public ICollection<MenuComponent> ChildMenus { get; }
    }

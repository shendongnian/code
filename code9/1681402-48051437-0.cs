    public abstract class MenuProperties
    {
        private static byte LastId = 0;
        public static List<MenuProperties> MyMenuList { get; } = new List<MenuProperties>();
        public byte Id { get; }
        public string MenuName { get; set; }
        public bool IsSubMenu { get; set; }
        protected MenuProperties()
        {
            Id = LastId++;
        }
        public abstract void AddMenu(MenuProperties menu);
        public abstract void DeleteMenu(MenuProperties menu);
    }
    public class MyMenu : MenuProperties
    {
        public MyMenu()
        {
            //This was not a Stack overflow, the MyMenuList was null; you didn't initialise it.
            MyMenuList.Add(this);
        }
        public override void AddMenu(MenuProperties menu)
        {
            MyMenuList.Add(menu);
        }
        public override void DeleteMenu(MenuProperties menu)
        {
            MyMenuList.Remove(menu);
        }
        public override string ToString()
        {
            return Id.ToString() + " " + MenuName;
        }
    }

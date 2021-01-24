    public class UI_Toggleable {
        public UIMenus MenuType {get;}
        // Subclasses must pass the correct menuType here
        protected UI_Toggleable(UIMenus menuType) {
            MenuType = menuType;
        }
    }
    public class  InventoryUI : UI_Toggleable {
        // Pass the proper menu type for storing inside the base class
        public InventoryUI() : base(UIMenus.Inventory) {
        }
    }

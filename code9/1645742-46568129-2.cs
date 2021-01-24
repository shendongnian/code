    public class UI_Toggleable {
        public abstract UIMenus MenuType {get;}
    }
    public class  InventoryUI : UI_Toggleable {
        public override UIMenus MenuType {
            get => UIMenus.Inventory
        }
    }

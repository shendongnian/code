    public class MenuItemRelation
    {
        public MenuItem PrimaryMenuItem { get; set; }
        public long PrimaryMenuItemId { get; set; }
        public MenuItem RelatedMenuItem { get; set; }
        public long RelatedMenuItemId { get; set; }
    }

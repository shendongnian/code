    public class HtNavigationMenuCategoryItem : ItemsControl
    {
        static HtNavigationMenuCategoryItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HtNavigationMenuCategoryItem),
                new FrameworkPropertyMetadata(typeof(HtNavigationMenuCategoryItem)));
        }
        public List<string> CategoryItems => new List<string> { "a", "b", "c" };
    }

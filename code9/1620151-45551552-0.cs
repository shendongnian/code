    public class MenuItemFilterFactory
    {
        public IMenuItemFilter Create(MenuItem menuItem)
        {
            if (menuItem.GetType() == typeof(ParentMenuItem))
            {
                return new ParentMenuItemFilter(this);
            }
            else if (/* create some other types*/)
            {
                ...
            }
        }
    }

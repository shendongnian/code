    public interface IMenuItemFilter
    {
    }
    public interface IMenuItemFilter<TMenuItemType> : IMenuItemFilter
            where TMenuItemType : MenuItem
    {
        TMenuItemType ApplySecurity(TMenuItemType menuItem);
    }

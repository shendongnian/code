    public interface IContextAction
    {
        string DisplayName { get; }
        Action Invoke { get; }
    }
    public class WindowViewModel
    {
        public IEnumerable<IContextAction> ContextActions { get; private set; }
        /* ... */
    }
   
        /* ... */
        ContextMenu cm = new ContextMenu();
        foreach (IContextAction action in viewModel.ContextActions)
        { 
            MenuItem item = new MenuItem(action.DisplayName);
            cm.MenuItems.Add(item);
            item.Click += (sender,args) => action.Invoke();
        }

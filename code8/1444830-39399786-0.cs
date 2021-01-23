    public class ContactListViewRenderer : ListViewRenderer, IUITableViewDelegate
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.WeakDelegate = this; // or. Control.Delegate
            }
        }
        public virtual void AccessoryButtonTapped(UITableView tableView, NSIndexPath indexPath)
        {
            // accessory tapped
        }
    }

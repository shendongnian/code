    public class ContactListViewRenderer : ListViewRenderer, IUITableViewDelegate
    {
        private AccessoryListView _formsControl;
        protected override void OnElementChanged(ElementChangedEventArgs<AccessoryListView> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.WeakDelegate = this; // or. Control.Delegate
            }
            if (e.NewElement != null)
               _formsControl = e.NewElement;
        }
    
        public virtual void AccessoryButtonTapped(UITableView tableView, NSIndexPath indexPath)
        {
            // accessory tapped
            if (_formsControl.OnAccessoryTapped != null)
               _formsControl.OnAccessoryTapped();
        }
    }

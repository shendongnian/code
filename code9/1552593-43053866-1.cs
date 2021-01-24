    public class FooterTableViewRenderer : TableViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;
            var tableView = Control as UITableView;
            var formsTableView = Element as TableView;
            tableView.WeakDelegate = new CustomFooterTableViewModelRenderer (formsTableView);
        }
        
        private class CustomFooterTableViewModelRenderer : TableViewModelRenderer
        {
            public CustomFooterTableViewModelRenderer(TableView model) : base(model)
            {
            }
            public override UIView GetViewForFooter(UITableView tableView, nint section)
            {
                return new UILabel()
                {
                    Text = TitleForFooter(tableView, section), // or use some other text here
                    TextAlignment = UITextAlignment.Center
                };
            }
        }
    }

    public override void ViewDidLoad ()
    {
        base.ViewDidLoad ();
        table = new UITableView(View.Bounds); // defaults to Plain style`
        string[] tableItems = new string[] {"a","b","c","d"};//your data to be bind ..You can pass list also
        table.Source = new TableSource(tableItems); //Or you can provide your table name. 
        Add (table);
    }
    //Create TableView Source to bind data which is coming from VC
    public class TableSource : UITableViewSource {
    
            string[] TableItems;
            string CellIdentifier = "TableCell";
    
            public TableSource (string[] items)
            {
                TableItems = items;
            }
    
            public override nint RowsInSection (UITableView tableview, nint section)
            {
                return TableItems.Length;
            }
    
            public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
            {
                UITableViewCell cell = tableView.DequeueReusableCell (CellIdentifier);
                string item = TableItems[indexPath.Row];
    
                //---- if there are no cells to reuse, create a new one
                if (cell == null)
                { cell = new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier); }
    
                cell.TextLabel.Text = item;
    
                return cell;
            }
    }

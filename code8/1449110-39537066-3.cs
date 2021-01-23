    public override void ViewDidLoad ()
    		{
    			//Create a custom table source
    			MyTableSource mySource = new MyTableSource ();
    
    			//Create a UITableView
    			UITableView tableView = new UITableView ();
    			CGRect tbFrame = this.View.Bounds;
    			tbFrame.Y += 20;
    			tbFrame.Height -= 20;
    			tableView.Frame = tbFrame;
    			tableView.Source = mySource;
    			tableView.RowHeight = 50;
    			this.Add (tableView);
    
    			//Handle delete event
    			mySource.DeleteCell += (cell) => {
    				//Get the correct row
    				Foundation.NSIndexPath indexPath = tableView.IndexPathForCell(cell);
    				//Remove data from source list
    				mySource.RemoveAt(indexPath.Row);
    				//Remove selected row from UI
    				tableView.BeginUpdates();
    				tableView.DeleteRows(new Foundation.NSIndexPath[]{indexPath},UITableViewRowAnimation.Fade);
    				tableView.EndUpdates();
    			};
    		}

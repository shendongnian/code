    public delegate void DeleteCellHandler(UITableViewCell cell);
    		public event DeleteCellHandler DeleteCell;
    
    		private string CellID = "MyTableCell";
    		private List<string> tableItems;
    
    		public MyTableSource ()
    		{
    			tableItems = new List<string> ();
    			for (int i = 0; i < 10; i++) {
    				tableItems.Add ("Test Cell " + i.ToString ());
    			}
    		}
    
    		public void RemoveAt(int row)
    		{
    			tableItems.RemoveAt (row);
    		}
    
    		#region implement from UITableViewSource
    
    		public override nint RowsInSection (UITableView tableview, nint section)
    		{
    			return tableItems.Count;
    		}
    
    		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
    		{
    			MyTableCell cell = tableView.DequeueReusableCell (CellID) as MyTableCell;
    			if (null == cell) {
    				//Init custom cell
    				cell = new MyTableCell (UITableViewCellStyle.Default, CellID);
    				//Bind delete event
    				cell.DeleteCell += delegate {
    					if(null != DeleteCell)
    						DeleteCell(cell);
    				};
    			}
    			cell.Title = tableItems [indexPath.Row];
    			return cell;
    		}
    
    		#endregion

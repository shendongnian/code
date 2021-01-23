    public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
    		{
    			MyTableCell cell = tableView.DequeueReusableCell (CellID) as MyTableCell;
    			if (null == cell) {
    				//Init custom cell
    				cell = new MyTableCell (UITableViewCellStyle.Default, CellID);
    				//Bind delete event
    				cell.CellClicked += delegate {
    					//Do something for click event
    				};
    			}
    			return cell;
    		}

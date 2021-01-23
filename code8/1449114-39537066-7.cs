    public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
    		{
    			MyTableCell cell = tableView.DequeueReusableCell (CellID) as MyTableCell;
    			if (null == cell) {
    				//Init custom cell
    				cell = new MyTableCell (UITableViewCellStyle.Default, CellID);
    				//Bind delete event
    				cell.DeleteCell += delegate {
    //					if(null != DeleteCell)
    //						DeleteCell(cell);
    					//Get the correct row
    					Foundation.NSIndexPath dIndexPath = tableView.IndexPathForCell(cell);
    					int deleteRowIndex = dIndexPath.Row;
    					Console.WriteLine("deleteRowIndex = "+deleteRowIndex);
    					//Remove data from source list
    					RemoveAt(deleteRowIndex);
    					//Remove selected row from UI
    					tableView.BeginUpdates();
    					tableView.DeleteRows(new Foundation.NSIndexPath[]{dIndexPath},UITableViewRowAnimation.Fade);
    					tableView.EndUpdates();
    				};
    			}
    			cell.Title = tableItems [indexPath.Row];
    			return cell;
    		}

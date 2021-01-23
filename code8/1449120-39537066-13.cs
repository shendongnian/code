    public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
            {
                MyTableCell cell = tableView.DequeueReusableCell (CellID) as MyTableCell;
                if (null == cell) {
                    cell = new MyTableCell (UITableViewCellStyle.Default, CellID);
                    //Bind delete event
                    cell.DeleteCell += delegate {
                        //Delete stuff            
                    };
                }
                cell.Title = tableItems [indexPath.Row];
                return cell;
            }

    public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
    {
        //use this method we can push to a new viewController
        //the first parameter is the identifier we set above
        parentVC.PerformSegue("NewPush", indexPath);
    }

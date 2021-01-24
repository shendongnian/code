    public delegate void CompleteEventHandler(string username);
	public class GoogleDriveViewController {
		 ...
		public event CompleteEventHandler OnComplete;
		public override void ViewWillDisappear(bool animated)
		{
			OnComplete?.Invoke(username);
		} 
	}
	public override void AccessoryButtonTapped(UITableView tableView, NSIndexPath indexPath)
    {
        if (indexPath.Row == 0)
        {                
            GoogleDriveViewController vc = Storyboard.InstantiateViewController("GoogleDriveViewController") as GoogleDriveViewController;
            vc.OnComplete += username =>{ theGoogleDriveCell.Label.Text = "GoogleDrive" + username  }; 
			or
            var index = indexPath;
			vc.OnComplete += username =>{ tableView.CellAt(index).Label.Text = "GoogleDrive" + username  };  
			navigationController.PushViewController(vc, true);
        }
        else if(indexPath.Row == 1)
        {
            DropBoxViewController vc = Storyboard.InstantiateViewController("DropBoxViewController") as DropBoxViewController;
            navigationController.PushViewController(vc, true);
        }
        else if(indexPath.Row==2)
        {
            BoxViewController vc = Storyboard.InstantiateViewController("BoxViewController") as BoxViewController;
            navigationController.PushViewController(vc, true);                
        }
    }

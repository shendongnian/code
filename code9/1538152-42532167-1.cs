    public class AddressbooksTableSource: UITableViewSource
	{
		
		private List<YAddressbook> addressbooks;
		private string cellIdentifier = "AddressbooksCell";
		private UINavigationController navigationController;
		public AddressbooksTableSource(List<YAddressbook> books, AddressbooksController ab)
		{
			addressbooks = books;
			this.navigationController = ab.ParentViewController as UINavigationController;
			Console.WriteLine(ab.displayModel);
		}
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			Console.WriteLine("Row selected" + addressbooks[indexPath.Row].displayname);
			UIStoryboard Storyboard = UIStoryboard.FromName("Main", null);
			AddressbooksController newab = Storyboard.InstantiateViewController("AddressbooksViewController") as AddressbooksController;
			newab.displayModel = "addresscards";
			navigationController.PushViewController(newab, true);
			tableView.DeselectRow(indexPath, true);
		}
		....
	}

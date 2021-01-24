    public class AddresscardsTableSource: UITableViewSource
	{
		private List<Ycard> addresscards;
		UINavigationController navigationController;
		AddressbooksController ab;
		string cellIdentifier = "AddresscardCell";
		public AddresscardsTableSource(List<Ycard> cards, AddressbooksController vc)
		{
			addresscards = cards;
			navigationController = vc.ParentViewController as UINavigationController;
			ab = vc;
			//navigationController = tableview;
		}
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			Console.WriteLine("Row selected" + addresscards[indexPath.Row].carddata);
			//UIStoryboard Storyboard = UIStoryboard.FromName("Main", null);
			ab.Card2Display = addresscards[indexPath.Row];
			ab.PerformSegue("segueShowAddress", indexPath);
			//AddresscardController ab = Storyboard.InstantiateViewController("AddresscardViewController") as AddressbooksController;
			//ab.TableView.Source = this;
			//navigationController.PushViewController(ab, true);
			tableView.DeselectRow(indexPath, true);
		}
		.....
	}

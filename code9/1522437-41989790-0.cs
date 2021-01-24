	public partial class ViewController : UIViewController
	{
		public ViewController() : base("ViewController", null)
		{
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			var companySource = new CompanyTableSource();
			tblView1.Source = companySource;
			companySource.ItemSelected += OnCompanyItemSelected;
		}
        //this will handle the ItemSelected event
        //here you will retrieve the data for the second UITableView
		void OnCompanyItemSelected(object sender, Company e)
		{
			//you can do it this way
			tblView2.Source = new CarTableSource(e.Id);
			List<Car> cars = GetCarsByCompanyId(e.Id);
			//or this whay
			tblView2.Source = new CarTableSource(cars);
		}
		List<Car> GetCarsByCompanyId(int id)
		{
			//Your logic to get the data goes here
			throw new NotImplementedException();
		}
    }
	public class CompanyTableSource : UITableViewSource
	{
		// You can use the whole object or just an integer (companyId)
		public event EventHandler<Company> ItemSelected;
		public IList<Company> Items { get; private set; } = new List<Company>();
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			var item = Items[indexPath.Row];
			ItemSelected?.Invoke(this, item);
		}
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			//Do your implementation
			throw new NotImplementedException();
		}
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return Items.Count;
		}
	}
	public class CarTableSource : UITableViewSource
	{
		public IList<Car> Items { get; private set; } = new List<Car>();
		public CarTableSource(int companyId)
		{ 
			//Get your data based on the companyId
		}
		//Or pass in the data already retreived. (I preffer this method)
		public CarTableSource(IList<Car> cars)
		{
			Items = cars;
		}
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			//Do your implementation
			throw new NotImplementedException();
		}
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return Items.Count;
		}
	}

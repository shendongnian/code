    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewExample : ContentPage {
		public ICollection<string> ListViewItems { get; set; }
		public ListViewExample() {
			this.ListViewItems = new List<string>();
			this.ListViewItems.Add("Foo");
			this.ListViewItems.Add("Bar");
			InitializeComponent();
		}
	}

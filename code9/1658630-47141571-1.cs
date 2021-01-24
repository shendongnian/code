	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			grid.DataSource = GetPersons();
			grid.DataBind();
		}
		public IEnumerable<Person> GetPersons()
		{
			for(int i = 0; i< 10; i++)
			{
				yield return new Person { FirstName = $"John{i}", LastName = "Doe", Age = i };
			}
		}
	}

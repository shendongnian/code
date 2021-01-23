    	protected void Page_Load(object sender, EventArgs e)
		{
		    List<Test> test = new List<Test>();
            test.Add(new Test() {firstName = "Adam", lastName = "Nowak"});
            test.Add(new Test() { firstName = "Jan",lastName = "Kowalski"});
            test.Add(new Test() { firstName = "Piotr", lastName = "Mały" });
            test.Add(new Test() { firstName = "Kazimierz", lastName = "Wąski" });
            RadSearchBox1.DataSource = test;
         
		}

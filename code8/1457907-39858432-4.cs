    static class Program
    {
    	[STAThread]
    	static void Main()
    	{
    		Application.EnableVisualStyles();
    		Application.SetCompatibleTextRenderingDefault(false);
    
    		CustomPropertyTypeDescriptor.Register(typeof(OrderLine),
    			CalculatedProperty.Create("Total", (OrderLine source) => source.Quantity * source.Price)
    		);
    
    		var form = new Form();
    		var dg = new DataGridView { Dock = DockStyle.Fill, Parent = form };
    		dg.DataSource = Enumerable.Range(1, 10).Select(n => new OrderLine
    		{
    			ItemNo = "Item#" + n,
    			Quantity = n,
    			Price = 10 * n
    		}).ToList();
    
    		Application.Run(form);
    	}
    }

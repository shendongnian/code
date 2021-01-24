    public class testowa1
	{
		public decimal CenaValue
		{
			get { return Cena.Cena; }
			set { Cena.Cena = value; }
		}
	}
    // in Fill
    var item = new testowa1()
    {
        ID = 1,
        Nazwa = "Pierwszy",
        Cena = new testowa2(),
        CenaValue = 32.22M
    };
    // after you added the list as the datasource
    dataGridView1.Columns["Cena"].Visible = false;

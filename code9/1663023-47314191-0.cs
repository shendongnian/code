    public class testowa1
	{
		public int ID { get; set; }
		public string Nazwa { get; set; }
		public decimal Cena
		{
			get { return _cena.Cena; }
			set { _cena.Cena = value; }
		}
		private testowa2 _cena = new testowa2();
	}
    var item = new testowa1()
    {
        ID = 1,
        Nazwa = "Pierwszy",
        Cena = 32.22M
    };

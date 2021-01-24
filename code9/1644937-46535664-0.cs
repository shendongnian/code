    [HttpGet]
    public ActionResult AddKorisnik()
    {
        //FOR DEBUGGING ONLY YOU CAN REMOVE THIS
        ViewBag.HasData = false;
        return View();
    }
    [HttpPost]
    public ActionResult AddKorisnik(string Ime, string Prezime, string JMBG, 
    string DatumRodjenja,
    	string BrojTelefona, string Email, string Sifra, string KorisnickoIme, char Spol)
    {
    	var x = new Korisnik
    	{
    		Ime = Ime,
    		Prezime = Prezime,
    		JMBG = JMBG,
    		DatumRodjenja = DatumRodjenja,
    		BrojTelefona = BrojTelefona,
    		Email = Email,
    		Sifra = Sifra,
    		KorisnickoIme = KorisnickoIme,
    		AdresaId = 1,
    		Spol = Spol
    	};
        //THIS IS JUST TO CHECK THAT WE GET ALL VALUES BACK IN POST
    	var js = new JavaScriptSerializer();
    	var xStr = js.Serialize(x);
    	ViewBag.Data = xStr;
    	ViewBag.HasData = true;
        ////////////////
    	return View();
    }

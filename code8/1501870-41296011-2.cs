    [HttpGet]
    public ActionResult Index()
    	{
            //All this is dummy data, you can bind Lists to Database data too.
    		List<District> lstDistricts = new List<District>();
            lstDistricts.Add(new District() { id=1, districtName="test01" });
            lstDistricts.Add(new District() { id = 2, districtName = "test02" });
    
            List<Tehsil> lstTehsil = new List<Tehsil>();
            lstTehsil.Add(new Tehsil() { id = 1, tehsilName = "test01" });
            lstTehsil.Add(new Tehsil() { id = 2, tehsilName = "test02" });
    
    
            List<UnionCouncil> lstUnionCouncil = new List<UnionCouncil>();
            lstUnionCouncil.Add(new UnionCouncil() { id = 1, ucName = "test01" });
            lstUnionCouncil.Add(new UnionCouncil() { id = 2, ucName = "test02" });
    
            StorePerson sp = new StorePerson();
            Person p = new Person();
            p.name = "Zulu Khan";
            p.id = 1;
            p.districtId = 2;
            p.UnionCouncilId = 1;
            p.tehsilId = 2;
            sp.person = p;
    
            sp.Districts = lstDistricts;
            sp.Tehsils = lstTehsil;
            sp.UnionCouncils = lstUnionCouncil;
    
            return View(sp);
    }

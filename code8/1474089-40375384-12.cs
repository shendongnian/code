	var fileContactIds = new List<string> { "5678765", "2135123", "12341234", "341234123", "12341234123", "2341234123", "341234123", "123412341", "13342354", "12342341", "123412322", "163341234", "2345234115", "8967896", "75626234" }; 
	//Read JSON from txt file. You can do it by your way
	string myjson = File.ReadAllText("Some.txt"); 
	string ctphno, ctadd, ctemail, cltax, ctfullname;
	List<ExtractedInfo> ei = new List<ExtractedInfo>(); 
	CTDetails ctdtl = new CTDetails();
	ExtractedInfo eiex = new ExtractedInfo();
	//Deserialize the JSON string to Object.
	Rootobject AllData = JsonConvert.DeserializeObject<Rootobject>(myjson);
	//Finding all data in List Class
	foreach(List lst in AllData.list) 
	{
		cltax = lst.clienttaxonomy; // you can directly put eiex.ocClientTaxonomy = lst.clienttaxonomy;
		foreach(Contact ct in lst.contacts)
		{
            //To check if value in the list matches the objectlistid in the Json object
			if(fileContactIds.Contains(lst.objectlistid.ToString()))
			{
				ctfullname = ct.fullname; // you can directly put eiex.ocFullName = ct.fullname;
				foreach(Contactdetail ctd in ct.contactdetails)
				{
					//Here we are trying to find the Match for Email. 
					if(Regex.IsMatch(ctd.contactdata, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
					{
						ctemail = ctd.contactdata;
						ctdtl.ocCTEmail = ctemail;
					}
					//Here We trying to find the match for Phone Number.
					else if(Regex.IsMatch(ctd.contactdata, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", RegexOptions.IgnoreCase))
					{
						ctphno = ctd.contactdata;
						ctdtl.ocCTPhoneNumber = ctphno;
					}
					//If NOthing matches than it might be address (Assumed)
					else
					{
						ctadd = ctd.contactdata;
						ctdtl.ocCTAddress = ctadd;
					}
				}
				eiex.ocFullName = ctfullname;
			}
		}
		eiex.ocClientTaxonomy = cltax;
		eiex.ocContactDetails = ctdtl;
		ei.Add(eiex);
	}

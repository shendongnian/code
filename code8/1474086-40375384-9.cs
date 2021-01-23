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
		eiex.ocClientTaxonomy = cltax;
		eiex.ocContactDetails = ctdtl;
		ei.Add(eiex);
	}

    string ctid, ctname, ctemail; //You can name it according to ur need.
	var AllData = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(YourJSONString);
	foreach(List lst in AllData.list)
	{
		foreach(Contact ct in lst.contacts)
		{
			foreach(Contactdetail ctd in ct.contactdetails)
			{
				ctid = ctd.contactid.ToString();
				ctname = ctd.contactdata;
				ctemail = ctd.contacttypeid.ToString();
			}
		}
	}

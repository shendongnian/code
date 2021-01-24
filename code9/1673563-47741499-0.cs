        string mess = member.Message;
        string cell = member.Cell;
		List<string> cellNumbers = new List<string>(); //LIST OF NUMBERs
        string pass = "xxxx";
        string user = "xxxx";
        string selectministries = member.SelectMinistries;
        string pathtoministries = "";
        pathtoministries = GetMinisry(selectministries);
        if (pathtoministries == "Youth")
        {
            var youthtable = from e in db.Youths
                             select e;
            var Entyouth = youthtable.ToList();
            foreach (Youth y in Entyouth)
            {
                string youthcell = y.ContactMobile.ToString();
                cell = youthcell;
				cellNumbers.add(cell);
            }
        }
       foreach(string number in cellNumbers) // send all the sms
	   {
		  string baseurl = "http://bulksms.2way.co.za/eapi/submission/send_sms/2/2.0?" +
		 "username=" + user + "&" +
		 "password=" + pass + "&" +
		 "message=" + mess + "&" +
		 "msisdn=" + number;
			WebRequest wrGETURL;
			wrGETURL = WebRequest.Create(baseurl);
			try
			{
				Stream objStream;
				objStream = wrGETURL.GetResponse().GetResponseStream();
				objReader = new StreamReader(objStream);
				objReader.Close();
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
		}

	public class MyVars {
		public string MailClass {get;set;}
		public string Selectivity {get;set;}
		public string MailForeigns {get;set;}
		public string ImbType {get;set;}
		public bool Postnet {get;set;}
        public int SomeNewVar {get;set;}
	}
	var myVars = new MyVars {
		MailClass = dict["MailClass"],
		Selectivity = dict["Selectivity"],
		MailForeign = dict["MailForeigns"],
		ImbType = dict["ImbType"],
		Postnet = dict["Postnet"]=="YES",
        SomeNewVar = int.Parse(dict["SomeNewVar"])
	}

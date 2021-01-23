     class AddPersonViewModel
    {
        public CommandHandler ButtonClick { get; set; }
        public AddPersonViewModel()
        {
            ButtonClick = new CommandHandler(AddPerson);
        }
        public string EnteredSurname { get; set; }
        public string EnteredName { get; set; }
        public string EnteredStreet { get; set; }
        public string EnteredHouseNumber { get; set; }
        public string EnteredPostalCode { get; set; }
        public string EnteredCity { get; set; }
        public string EnteredPhoneAreaCode { get; set; }
        public string EnteredPhoneNumber { get; set; }
        public string EnteredEmail { get; set; }
       
        void AddPerson()
        {
            File.AppendAllText(@"C:\some_file.csv", "\r\n" + 
                EnteredSurname + "," +
                EnteredName + "," +
                EnteredStreet + "," +
                EnteredHouseNumber + "," +
                EnteredPostalCode + "," +
                EnteredCity + "," +
                EnteredPhoneAreaCode + "," +
                EnteredPhoneNumber + "," +
                EnteredEmail,
                Encoding.GetEncoding("iso-8859-1")
                );
        }
    }
    }

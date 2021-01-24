        public class Account
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime DOB { get; set; }
        }
        public string Hello { get; set; }
        public void Page_Load(object sender, EventArgs e)
        {
            Account account = new Account
            {
                Name = "John Doe",
                Email = "john@microsoft.com",
                DOB = new DateTime(1980, 2, 20, 0, 0, 0, DateTimeKind.Utc),
            };
            this.Hello = JsonConvert.SerializeObject(account, Formatting.Indented);
        }

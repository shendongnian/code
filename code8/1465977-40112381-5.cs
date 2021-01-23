    protected void Page_Load(object sender, EventArgs e)
        {
            ListView1.DataSource = GetAllUsers();
            ListView1.DataBind();
        }
        public class User
        {
            public int ID { get; set; }
            public string name { get; set; }
            public string Status { get; set; }
        }
        public List<User> GetAllUsers()
        {
            User aUser = new User();
            List<User> Users = new List<User>();
            Users.Add(new User() { ID = 1, name = "AT-2016", Status = "1" } );
            Users.Add(new User() { ID = 2, name = "AT-2014", Status = "0" } );
            return Users;
        }
        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            for (int i = 0; i < ListView1.Items.Count(); i++)
            {
                //Get the Label by row
                Label status = (Label)ListView1.Items[i].FindControl("label3");
                Button button1 = (Button)ListView1.Items[i].FindControl("button1");
                if (status.Text == "1")
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
        }

    BindingList<User> source = new BindingList<User>();
    public void ExampleColumnSetup()
    {
        DataGridViewColumn column = new DataGridViewTextBoxColumn();
        column.DataPropertyName = "IP";
        column.Name = "User";
        _GridView.Columns.Add(column);
    }
    public void AddUser(string ip)
    {
        source.add(new User(IP = ip));
        _GridView.DataSource = null;
        _GridView.DataSource = source;
    }
    public class User()
    {
        public string IP { get; set; }
        public User(string IP)
        {
            this.IP = IP;
        }
    }

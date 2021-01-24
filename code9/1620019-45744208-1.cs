    public List<request> requests = new List<request>();
    protected void Page_Load(object sender, EventArgs e)
    {
        //create some dummy data
        for (int i = 0; i < 10; i++)
        {
            request r = new request() { Id = i, date = DateTime.Now };
            r.applicant = new applicant() { Name = "Applicant " + i, ID = 1 + 100 };
            r.software = new software() { Name = "Software " + i };
            requests.Add(r);
        }
        if (!Page.IsPostBack)
        {
            Repeater1.DataSource = requests;
            Repeater1.DataBind();
        }
    }
    public class request
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public applicant applicant { get; set; }
        public software software { get; set; }
    }
    public class applicant
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class software
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

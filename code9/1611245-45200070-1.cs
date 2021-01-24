    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListView1.DataSource = new List<User>
                {
                    new User {Id = 1, Name = "John"},
                    new User {Id = 2, Name = "Marry"},
                    new User {Id = 3, Name = "Nancy"},
                    new User {Id = 4, Name = "Eric"},
                };
                ListView1.DataBind();
            }
        }
    
        protected void RemoveButton_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
    
        }
    
        protected void ListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                User user = e.Item.DataItem as User;
            }
        }
    }

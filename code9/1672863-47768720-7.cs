                    public partial class _Default : Page
                    {
                        private string strContent;
                        // notice the property that the tables can read as in the aspx code above
                        public String ContentString
                        {
                            get { return strContent; }
                        }
                        protected void Page_Load(object sender, EventArgs e)
                        {
                            strContent = "Your Content";
                            Repeaterp.DataBind();
                            // here's how to access the two tables
                            Table Table1 = (Table)Repeaterp.Controls[0].FindControl("Table1");
                            Table Table2 = (Table)Repeaterp.Controls[0].FindControl("Table2");
                        }
                    }

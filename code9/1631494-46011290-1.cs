    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbx_Marked.Items.Add(new ListItem("Option 1", "1"));
                lbx_Marked.Items.Add(new ListItem("Option 2", "2"));
                lbx_Marked.Items.Add(new ListItem("Option 3", "3"));
            }
        }
        protected void lbx_Marked_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a;
            int b;
            b = lbx_Marked.SelectedIndex;
            if (lbx_Marked.SelectedIndex == -1)
            {
                a = " No Selection Made";
            }
        }
    } 

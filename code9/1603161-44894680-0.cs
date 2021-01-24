    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] myStrings = new string[] { "Example Value", "Not a Thing", "Many Things", "All the Thing" };
            cblThingy.DataSource = myStrings;
            cblThingy.DataBind();
        }
        protected void btnPushMe_Click(object sender, EventArgs e)
        {
            //for all the things
            foreach(ListItem itemThing in cblThingy.Items)
            {
                //set a default of not selected
                itemThing.Selected = false;
                //if the text is the same
                //you can have any check you like here
                if (itemThing.Text == txtThing.Text)
                    //say that it's selected
                    itemThing.Selected = true;
            }
        }
    }

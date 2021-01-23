        static bool enable = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DynamicButton();
            }
            else if (enable)
            {
                DynamicButton();
            }
        }
        protected void btnBindMapping_Click(object sender, EventArgs e)
        {
            enable = true;
            DynamicButton();
        }
        protected void DynamicButton()
        {
            LinkButton lb = new LinkButton();
            lb = new LinkButton();
            lb.Text = songName + "</br>"; //LinkButton Text
            lb.ID = song.Key.ToString(); // LinkButton ID’s
            lb.CommandArgument = Convert.ToString(song.Key);
            lb.CommandName = Convert.ToString(song.Key);
            lb.Click += new EventHandler(test_Click);
            this.form1.Controls.Add(lb);
            PlaceHolder1.Controls.Add(lb);
        }
        protected void test_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('done'); </script>");
        }
 

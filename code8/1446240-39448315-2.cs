        //declare global integer
        int controlCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //check if the viewstate exists
            if (ViewState["controlCount"] != null)
            {
                try
                {
                    //convert viewstate to int
                    controlCount = Convert.ToInt32(ViewState["controlCount"]);
                }
                catch
                {
                }
            }
            //call the funcion to add the controls on every page load
            addControls();
        }
        protected void add_Click(object sender, EventArgs e)
        {
            //pretty obvious what this does...
            controlCount++;
            addControls();
        }
        private void addControls()
        {
            var container = testje.ContentTemplateContainer;
            container.Controls.Clear();
            //loop the currect control count
            for (int i = 0; i < controlCount; i++)
            {
                Literal literal = new Literal();
                literal.Text = "Literal " + i;
                literal.ID = "myLiteral_" + i;
                container.Controls.Add(literal);
                Button btn = new Button();
                btn.Text = "Button " + i;
                btn.ID = "myButton_" + i;
                btn.Click += new EventHandler(btnClick);
                container.Controls.Add(btn);
            }
            //set the viewstate again with the new control count
            ViewState["controlCount"] = controlCount;
        }
        
        protected void btnClick(object sender, EventArgs e)
        {
            //cast the sender as a button
            Button btn = sender as Button;
            //split the ID to get the count
            string [] btnNr = btn.ID.Split('_');
            //find the literal that goes with the clicked button
            Literal literal = testje.FindControl("myLiteral_" + btnNr[1]) as Literal;
            //alert the literal text
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "doPopup", "alert('" + literal.Text + "')", true);
        }

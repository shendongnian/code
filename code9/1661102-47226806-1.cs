    protected void Page_Load(object sender, EventArgs e)
            {
                Button dodaj = new Button();
                dodaj.Text = "Click Me!";
            dodaj.Attributes.Add("runat", "server");
            dodaj.Attributes.Add("type", "submit");
            dodaj.Attributes.Add("onclick", "addKosarica");
            newDivInfo.Controls.Add(dodaj);
            dodaj.Click += Dodaj_Click1;
        }
    
        private void Dodaj_Click1(object sender, EventArgs e)
        {
            Response.Write("Ok");
        }

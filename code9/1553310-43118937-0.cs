    protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * FROM Ansatt WHERE epost='" + brukernavn.Text + "' and passord='" + passord.Text + "'");
            cmd.Connection = con;
            int OBJ = Convert.ToInt32(cmd.ExecuteScalar());
    
            if (OBJ > 0)
    
                {
                Session["name"] = brukernavn.Text;
                Response.Redirect("KunstnerAdmin.aspx");
            }
            else
                {
                    melding.Text = "Feil brukernavn/passord";
                }
            if (brukernavn.Text == "")
            {
                melding.Text = "Du må fylle inn brukernavn";
    
            }
            if (passord.Text == "")
            {
                melding.Text = "Du må fylle inn passord";
            }
            }

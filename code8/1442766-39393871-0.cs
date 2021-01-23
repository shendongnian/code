         private void Form2_Load(object sender, EventArgs e)
        {
            string constr = @"Data Source=DESKTOP-J6KRI77\SQLEXPRESS; Initial Catalog = SELLnBUY; Integrated Security = true";
            string cmdstr = "SELECT Apartment_No FROM Apartment";
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = new SqlCommand(cmdstr, con);
            con.Open();
            SqlDataReader r = com.ExecuteReader();
            
            while (r.Read())
            {
              int room = int.Parse(r["Apartment_No"].ToString());
                switch(room)
                {
                    case 101:               
                            button1.Enabled = false;
                            break;                       
                    case 102:                       
                            button2.Enabled = false;
                            break;
                        case 103:
                            button3.Enabled = false;
                            break;
                    case 104:
                            button4.Enabled = false;
                            break;
                }
            }
            con.Close();

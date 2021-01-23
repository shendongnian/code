    protected void Page_Load(object sender, EventArgs e)
    {
        var pinNum = MySession.Current.focusParcel;
    
        if (pinNum == 0)
           Response.Redirect("./ParcelSearch.aspx");
    
        String sql = ConfigurationManager.ConnectionStrings["Recorder"].ConnectionString;
    
        using(SqlConnection connection = new SqlConnection(sql))
        {
           connection.Open();
    
           SqlCommand command = new SqlCommand("Select PARCEL, PIN_TXT, Owner, Address1, Address2, CSZ, ACRES, LEGAL, Active FROM[ParcelView] WHERE PARCEL =@PinNum ", connection);
    
           //protect from sql injection
           command.Parameters.AddWithValue(@PinNum, pinNum);
           using(SqlDataReader selectedParcel = command.ExecuteReader())
           {
               if(!selectedParcel.HasRows)
                   return;
                 
               SetLabels(selectedParcel);      
            }    
         }
            
     }
    
     private void SetLabels(SqlDataReader selectedParcel)
     {
         lblPIN_Num.Text = selectedParcel["PARCEL"].ToString();
         lblPIN_TXT.Text = selectedParcel["PIN_TXT"].ToString();
         lblDateTime.Text = DateTime.Now.ToString("MMMM dd, yyyy");
         lblOwner.Text = selectedParcel["Owner"].ToString();
         lblAddress1.Text = selectedParcel["Address1"].ToString();
         lblAddress2.Text = selectedParcel["Address2"].ToString();
         lblCSZ.Text = selectedParcel["CSZ"].ToString();
         lblAcres.Text = string.Format("{0} Acres", selectedParcel["ACRES"]);
         lblLegal.Text = selectedParcel["LEGAL"].ToString();
         if (selectedParcel["Active"].ToString() == "A")
         {
             lblInactive.Text = " (ACTIVE)";
         }
         else
         {
             lblInactive.Text = " (INACTIVE)";
             lnkAddDocument.Visible = false;
         }
            
         lblCurrentUser.Text = Page.User.Identity.Name;
    }

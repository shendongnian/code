    comboBox1.Items.Clear(); //Clear the dropdown first
    //Open the connection, set SqlCommandType and Text
    using (SqlDataReader reader = sqlcmd.ExecuteReader())
      {
         comboBox1.DataSource = reader; //Assign DataReader to the DataSource of the Combobox
         comboBox1.DataValueField = "usr_entrada";
         comboBox1.DataTextField = "no_servicio";
         comboBox1.DataBind();
         //Here you can insert a new item at Index 0 of the Combobox.
         //For your case, keep the "Default Text" blank
         comboBox1.Items.Insert(0, new ListItem("--Default Text--", "-1"));
      }
    //close the connection

    //btnSubmit_Click
    if (ReturnCode == -1)
    {
          lblMsg.Text = "Already Data present";
          lblMsg.ForeColor = System.Drawing.Color.Red;
          ClearFields();
    }
    else
    {
          lblMsg.Text = "Data inserted successfully";
          lblMsg.ForeColor = System.Drawing.Color.Green;
          ClearFields();
          BindTeamName(); //re-bind the initial dropdown so you can select a new team
     }

     protected void txtTimeBegin_TextChanged(object sender, EventArgs e) 
     {
      Session["TimeStart"] = txtTimeBegin.Text;
      gvAvailableVets.DataBind();
    // Used for debugging
      lblDebug.Text = Session["TimeStart"].ToString();
     }
     protected void txtTimeEnd_TextChanged(object sender, EventArgs e) 
     {
      Session["TimeFinish"] = txtTimeEnd.Text;
      gvAvailableVets.DataBind();
     }

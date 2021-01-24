    if(TextBox2.Text != "" && TextBox2.Text != null)
    {
      Session["Lname"] = TextBox2.Text;
    }
    else
    {
     // just for test in case TextBox2.Text is null,
      Session["Lname"] = "it is null..";
    }

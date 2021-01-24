    if (!CheckLogin(txtHosEmail.Text.ToString().Trim()))
    {
        showimage.Visible = false;
        hideimage.Visible = true;
    }
    else
    {
        hideimage.Visible = true;
        lblMsg.Text = "This Email is InCorrect";
    }

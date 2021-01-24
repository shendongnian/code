    if (e.Row.Visible == true)
                    {
                        numVisible += 1;
    
                        Label lblRowCounter = (Label)e.Row.FindControl("lblRowCounter");//take lable id
    
                        lblRowCounter.Text = numVisible.ToString();
    
                    }

    you can try like....
    protected void lnkbtnKeySearch_Click(object sender, EventArgs e)
    {
               Session["myNewString"] = "Change the value of the string";
    }
    private void LoadData()
    {
        {
                string filterText = Session["myNewString"].ToString();;
        }
    }

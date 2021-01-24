    protected void Submit_Click(object sender, EventArgs e)
    {
        if (!this.IsValid)
             return;
        int score = 0;
        List<RadioButtonList> list = new List<RadioButtonList>() { RadioButtonList1, RadioButtonList2, RadioButtonList3, RadioButtonList4, RadioButtonList5, RadioButtonList6, RadioButtonList7, RadioButtonList8, RadioButtonList9, RadioButtonList10 };
        foreach (var element in list)
        {
             if (element.SelectedValue == "Correct")
             {
                  score++;
             }
        }
        Response.Write("you scored: " + score);
        Button1.Visible = false;
    }

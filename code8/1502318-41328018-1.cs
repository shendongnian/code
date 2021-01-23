    for (int i = 1; i < gvAnswers.Rows.Count; i++)
    {
        int V;
        RadioButton rBtnAnswer = gvAnswers.Rows[i].FindControl("rbtnSelect") as RadioButton;
        if (rBtnAnswer.Checked)
        {
            V = 1;
        }
        else
        {
            V = 0;
        }
        Label txtAnswered = gvAnswers.Rows[i].FindControl("lblAnswer") as Label;
        obj.ExeQuery("insert into tblResult values('" + V + "','" + txtAnswered.Text + "',Null,NULL,NULL,Null)");
    }

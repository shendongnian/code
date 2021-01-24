    protected void Button1_Click(Object sender, EventArgs e)
    {
      string emailList = "";
      foreach (GridViewRow row in GridView1.Rows)
      {
        CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
        if (cb.Checked)
        {
          string val = GridView1.DataKeys[row.RowIndex].Value.ToString();
          emailList += val;
        }
      }
      ClientScriptManager csm = Page.ClientScript;
      csm.RegisterClientScriptBlock(GetType(), "SendMail", string.Format("SendMail(\"mailto:?bcc={0}\");", emailList), true);
    }

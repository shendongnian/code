    protected void btn_----_Click(object sender, EventArgs e)
    {
        string response = "";
        for (int i = 0; i < mylist.Count; i++)
        {
            if (mylist[i].id == ddl_idList.SelectedValue)
            {
                Session["selectedidObj"] = mylist[i];
                response = "<script>window.open('../folder/mypage.aspx','_blank');</script>";
                break;
            }
        }
    
        ClientScript.RegisterClientScriptBlock(GetType(), "Comment", response, true);
    }

    for (int i = 0; i < dt.Rows.Count; i++)
    {
         // if the DataTable has 2 columns,
         // 0 = USER_ID, 1 = USER_NAME
         builder.Append(String.Format("<option value='{0}'>{1}</option>", dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString()));
    }
    // Button event handler
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        input_selected.Value = username.Value;
    }
    <%-- datalist changed to select element --%>
    <select id="username" runat="server" ...></select>

     public void TextBox1_OnTextChanged(object sender, EventArgs e)
            {
                ddl.DataSource = null;
                ddl.DataBind();
                ddl.DataTextField = "Text";
                ddl.DataValueField = "Value";
                ddl.DataSource = (from ListItem b in ddl.Items
                                 select b.Selected ? new ListItem(TextBox1.Text, b.Value) : b).ToList();
                ddl.DataBind();
            }

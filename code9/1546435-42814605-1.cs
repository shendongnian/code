    protected void MyDropDownList_DataBound(object sender, EventArgs e)
            {
                var ddl = sender as DropDownList;
                foreach (ListItem item in ddl.Items)
                {
                    if (Gender == "Male")
                    {
                        item.Attributes.Add("disabled", "disabled");
                    }
                }
            }

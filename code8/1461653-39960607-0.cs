        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> selectedValues = new List<string>();
            foreach (ListItem item in myCheckBoxList.Items)
            {
                if (item.Selected)
                {
                    selectedValues.Add(item.Value);
                }
            }
            Label1.Text = selectedValues.Count.ToString();
        }

        private void countItemsInGrid()
        { 
            int totalCount = 0;
            for (int i = 0; i < SettingsB.Rows.Count; i++)
            {
                TextBox tb = SettingsB.Rows[i].FindControl("txtPayamt") as TextBox;
                try
                {
                    totalCount += Convert.ToInt32(tb.Text);
                }
                catch
                {
                }
            }
            TextBox1.Text = "Total count is: " + totalCount;
        }

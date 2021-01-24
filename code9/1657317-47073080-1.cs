        protected void BtnRetreive_Click(object sender, EventArgs e)
        {
            String value;
            value = Cache.Get("UserName").ToString();
            Label1.Text = value;
        }

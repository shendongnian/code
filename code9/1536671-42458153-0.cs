        private void BindData()
        {
            List<Data> data = new List<Data>();
            decimal maxValue = 435;
            data.Add(new Data("Familie", 435m));
            data.Add(new Data("Bank", 1.25m));
            data.Add(new Data("Hosting", 12.1m));
            for (int i = 0; i < data.Count; i++)
            {
                Data item = data[i];
                item.ValueString = buildSpaces(100 - (int)((item.Value / maxValue) * 100)) + item.Value.ToString();
            }
            dg.DataSource = data;
            dg.DataBind();
        }
        private string buildSpaces(int number)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < number; i++)
                sb.Append("&nbsp;");
            return sb.ToString();
        }

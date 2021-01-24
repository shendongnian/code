    using System.Data;
     private void initializeDropDownList(String queryName, String rowName, DropDownList dd)
        {
            List<String> listData = new List<String>();
            DataSet dataset = new DataQuery("custom.PageType." + queryName).Execute();
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                listData.Add(row[rowName].ToString());
            }
            String[] arrayData = listData.ToArray();
            foreach (String data in arrayData)
            {
                if (data.Equals("")) { continue; }
                else
                {
                    dd.Items.Add(new ListItem(data));
                }
            }
        }

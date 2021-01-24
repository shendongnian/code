        protected void Page_Load(object sender, EventArgs e)
        {
            var StatsList = new BindingList<ExpandoObject>();
            // Add seed record to generate columns in DataGridView
            dynamic ds = new ExpandoObject();
            ds.key = "0000";
            ds.Name = "Bob";
            ds.Number = "2255442";
            dynamic ds2 = new ExpandoObject();
            ds2.key = "0001";
            ds2.Name = "Nathan";
            ds2.Number = "1217479";
            StatsList.Add(ds);
            StatsList.Add(ds2);
            GridView1.DataSource = ExpandoListToDataTable(StatsList);
            GridView1.DataBind();
        }
        protected DataTable ExpandoListToDataTable(BindingList<ExpandoObject> d)
        {
            var dt = new DataTable();
            foreach (var a in d)
            {
                foreach (var key in ((IDictionary<string, object>)a).Keys)
                {
                    if (!dt.Columns.Contains(key))
                    {
                        dt.Columns.Add(key);
                    }
                }
                dt.Rows.Add(((IDictionary<string, object>)a).Values.ToArray());
            }
            return dt;
            
        }

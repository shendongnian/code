    public static DataTable PopulateRec(int list_id, string web_app, string host_auth)
    {
        DataTable dt = new DataTable();
        List<string> Column = Get_Column(list_id, web_app, host_auth);
        for (int i = 0; i < Column.Count(); i++)
        {
            DataColumn datacolumn = new DataColumn();
            datacolumn.ColumnName = Column[i].ToString();
            dt.Columns.Add(datacolumn);
        }
        List<MyItem> Items = Get_Item(list_id, web_app, host_auth);
        if (Items.Count != 0)
        {
            int ItemCount = Convert.ToInt32((from Itms in Items
                                             select Itms.Item_id).Max());
            for (int j = 0; j <= ItemCount; j++)
            {
                dt.Rows.Add();
                List<MyItem> IndvItem = (from Indv in Items
                                         where Indv.Item_id == j
                                         select Indv).ToList();
                foreach (var val in IndvItem)
                {
                    dt.Rows[j][val.title] = val.value;
                }
                IndvItem = null;
            }
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (dt.Rows[k][0].ToString() == string.Empty)
                {
                    dt.Rows[k].Delete();
                }
            }
        }
        Column = null;
        Items = null;
        return dt;
    }
    private static List<string> Get_Column(int list_id, string web_app, string host_auth)
    {
        List<string> content_db = new List<string>();
        List<string> columnname = new List<string>();
        Config_DB_Context configdb = new Config_DB_Context("dms_config");
        content_db = (from c in configdb.site_mapping
                      where c.host_auth == host_auth
                      && c.web_app == web_app
                      select c.content_db).ToList();
        for(int i = 0; i < content_db.Count(); i++)
        {
            Content_DB_Context contentdb = new Content_DB_Context(content_db[i]);
            columnname = (from c in contentdb.content
                              where c.content_type == "Column"
                              && c.list_id == list_id
                              select c.title).ToList();
        }
        content_db = null;
        return columnname;
    }
    private static List<MyItem> Get_Item(int list_id, string web_app, string host_auth)
    {
        List<string> content_db = new List<string>();
        List<MyItem> Itm = new List<MyItem>();
        Config_DB_Context configdb = new Config_DB_Context("dms_config");
        content_db = (from c in configdb.site_mapping
                      where c.host_auth == host_auth
                      && c.web_app == web_app
                      select c.content_db).ToList();
        for (int i = 0; i < content_db.Count(); i++)
        {
            Content_DB_Context contentdb = new Content_DB_Context(content_db[i]);
            Itm = (from c in contentdb.content
                   where c.content_type == "Item"
                   && c.list_id == list_id
                   select new MyItem
                   {
                       col_id = (int)c.column_id,
                       list_id = (int)c.list_id,
                       title = c.title,
                       value = c.value,
                       Item_id = (int)c.item_id,
                       hidden = c.hidden
                   }).ToList();
        }
        content_db = null;
        return Itm;
    }

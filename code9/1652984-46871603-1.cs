       var uname = DB.TBL_USAGE.Where(x => x.UName != null).ToList();
        List<usage> lst = new List<usage>();
        foreach (var item in DB.TBL_USAGE)
        {
            lst.Add(new usage { uname = item.UName, bytesout = item.Bytesout });
        }
        dataGridView1.DataSource = lst ;
\
        

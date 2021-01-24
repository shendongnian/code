    private void bgwLoader_DoWork(object sender, DoWorkEventArgs e)
    {
        // initialize the datatable once
        DataTable dt = new DataTable();
        dt.Columns.Add("Domain", typeof(string));
        dt.Columns.Add("Page Authority", typeof(string));
        dt.Columns.Add("Domain Authority", typeof(string));
        // e.Argument holds the array with urls, don't forget to cast it
        foreach (var url in (string[]) e.Argument)
        {
            var webClient = new System.Net.WebClient();
            //get string from web
            string rawJSON = webClient.DownloadString("https://semanthic.com/api.php?api=masiting&dom=" + url);
            Trace.WriteLine(rawJSON);
            // convert json to the series obj
            Domain Doms = JsonConvert.DeserializeObject<Domain>(rawJSON);
            
            string P_A = Doms.Pa;
            string D_A = Doms.Da;
            DataRow row = dt.NewRow();
            row[0] = url;
            row[1] = P_A;
            row[2] = D_A;
            dt.Rows.Add(row);
        }
        // make sure the Completed event gets our result
        e.Result = dt;
    }

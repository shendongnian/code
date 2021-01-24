    Public ActionResult TestPage()
    {
        DataTable table = new DataTable();
        table.Columns.Add("Link Column", typeof(HtmlString));
        HtmlString link = new HtmlString("<a href= **Your Link Here** >Click Here</a>")
        Table.Rows.Add(link)
        
        return View(table);
    }

    public void RenderButtonTable(List<List<string>> names)
    {
        var layout = new TableLayout.LayoutParams
            (
                TableLayout.LayoutParams.MatchParent,
                TableLayout.LayoutParams.MatchParent, 
                1.0f
            );
        tablerow.LayoutParameters = layout;
        foreach (var row in names)
        {
            TableRow tablerow = new TableRow(this);
            tablerow.LayoutParameters = layout;
            table.AddView(tablerow);
            foreach (var col in row)
            {
                Button btn = new Button(this);
                btn.Text = col;
                tablerow.AddView(btn);
            }
        }
    }

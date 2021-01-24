    @{
                List<WebGridColumn> columns = new List<WebGridColumn>();
                // id column
                WebGridColumn idColumn = new WebGridColumn();
                idColumn.ColumnName = "ID";
                idColumn.Style = "";
                idColumn.Format = @<text><span>@item.ID</span></text>;
                columns.Add(idColumn);
    }
                @grid.Table(tableStyle: "span12",
                    rowStyle: "",
                    columns: columns,
                    displayHeader: true,
                    htmlAttributes: new { id = "tableId", style = "margin-bottom: 15px;" }
                    );
  

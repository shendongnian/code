    DataTable tbl = new DataTable();
    tbl = ViewData["PivotDataTable"] as DataTable;
    List<String> columns = new List<String>();
    for (int c = 0; c < tbl.Columns.Count; c++)
    {
        string colname = tbl.Columns[c].Caption.ToString();
        if (colname.Contains("_"))
        {
            columns.Add(colname.Substring(0, colname.IndexOf("_")));
        }
        else
        {
            columns.Add(colname);
        }
    }
    List<String> cols = new List<String>();
    cols = columns.Distinct().ToList();
}
    <table class="table table-striped table-bordered table-hover" id="example1">
    <thead>
        <tr>
            <td rowspan="2" class="text-center"><b>CUSTOMERS</b></td>
            @for (int i = 1; i < cols.Count; i++)
            {
                <th colspan="3" scope="colgroup" class="text-center">@cols[i]</th>
            }
            <th rowspan="1" scope="colgroup" class="text-center">TOTAL</th>
        </tr>
        <tr>
            @for (int i = 0; i < cols.Count - 1; i++)
            {
                int sira = i + 1;
                <th scope="col">DEBT</th>
                <th scope="col">CREDIT</th>
                <th scope="col" style="background-color:azure">BALANCE</th>
            }
        </tr>
    </thead>
    <tbody>
        @foreach (System.Data.DataRow row in tbl.Rows)
        {
            <tr>
                @foreach (var cell in row.ItemArray)
                {
                    if (String.IsNullOrEmpty(cell.ToString()))
                    {
                        <td>0.00</td>
                    }
                    else
                    {
                        <td>@cell</td>
                    }
                }
            </tr>
        }
    </tbody>

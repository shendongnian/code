    int Month = Convert.ToDateTime(txtFromDate.Text).Month;
    int Year= Convert.ToDateTime(txtFromDate.Text).Year;
    
     var Query = from row in dt.AsEnumerable() //List
                           let date = row.Field<DateTime>("date")
                           where date.Month == Month && date.Year == Year
                           select row;
        DataRow[] dr = Query.ToArray();

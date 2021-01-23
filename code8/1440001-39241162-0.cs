    if (e.Row.RowType == DataControlRowType.DataRow)
    {
                DateTime dt;
                if (DateTime.TryParse(e.Rows.Cells(2).Text, out dt))
	            {
	                if (dt < DateTime.Now)
                    {
                        //color code
                    }
	            }
    }

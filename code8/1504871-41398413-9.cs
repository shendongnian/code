    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    dt.TableName = "Tabela";
    dt.Columns.Add("Name");
    dt.Columns.Add("Surname");
    dt.Columns.Add("PESEL");
    dt.Columns.Add("Room");
    ds.Tables.Add(dt);
    foreach (Booking item in bookings)
    {
        DataRow dr = ds.Tables["Tabela"].NewRow();
        dr["Name"] = item.Name;
        dr["Surname"] = item.Surname;
        dr["PESEL"] = item.PESEL;
        dr["Room"] = item.Room;
        ds.Tables["Tabela"].Rows.Add(dr);
    }
    ds.WriteXml("D:\\data.xml");

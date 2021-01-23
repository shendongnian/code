        //attention to eventual new records appended to the list you may lose them
        
        DataSet ds = new DataSet();
        ds.ReadXml("D:\\data.xml");
        bookings.Clear(); //<<== avoids dirty loading (duplicates)
        foreach (DataRow item in ds.Tables["Tabela"].Rows) {
            bookings.Add(new Booking() {
                Name = item["Name"].ToString(),
                Surname = item["Surname"].ToString(),
                PESEL = item["PESEL"].ToString(),
                Room = item["Room"].ToString()
            });
        }
        listBox.DataSource = null;
        listBox.DataSource = bookings; //use the datasource  property
        listBox.DisplayMember = "Room";
        listBox.ValueMember = "PESEL";

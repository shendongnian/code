    IFormatProvider fP = new CultureInfo("it");
    DataTable tmp = new DataTable();
    tmp.Columns.Add("CodArt", typeof(string));
    tmp.Columns.Add("Descrizione", typeof(string));
    tmp.Columns.Add("Prezzo", typeof(decimal));
    using (var rd = new StreamReader("yourFileName", Encoding.GetEncoding("iso-8859-1")))
    {
        while (!rd.EndOfStream)
        {
            try
            {
                var nextLine = Regex.Replace(rd.ReadLine(), @"\s+", " ");
                while (nextLine.Split(';').Length < 3)
                {
                    nextLine = nextLine.Replace("\r\n", "") + Regex.Replace(rd.ReadLine(), @"\s+", " ");
                }
                var splits = nextLine.Split(';');
                DataRow dR = tmp.NewRow();
                dR[0] = splits[0];
                dR[1] = splits[1];
                string Price = splits[2];
                dR[2] = decimal.Parse(Price, fP);
                tmp.Rows.Add(dR);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    
    using (var conn = db.apriconnessione())
    {
        var sBC = new SqlBulkCopy(conn);
        conn.Open();
        sBC.DestinationTableName = "yourTableName";
        sBC.WriteToServer(tmp);
        conn.Close();
    }

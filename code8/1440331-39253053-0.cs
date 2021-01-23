    var day = new DateTime(2016, 9, 4);
    using (var cmd = new OleDbCommand("SELECT * FROM Prenotazioni WHERE DataArrivo=?", conn))
    {
        cmd.Parameters.AddWithValue("?", day);
        using (OleDbDataReader rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                // do stuff
            }
        }
    }

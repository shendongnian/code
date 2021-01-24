    public void simpan_informasiData()
    {
        if(string.IsNullOrEmpty(field_judul.text))
        {
            print("You must fill in then field...!!!");
        }
        else
        {
            var sql = "INSERT INTO t_informasi(judul,keterangan,waktu) VALUES (@judul,@keterangan,datetime());";
            using (var cmd = dbCon.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@judul",field_judul.text);
                cmd.Parameters.AddWithValue("@keterangan",field_keterangan.text);
                cmd.ExecuteNonQuery();
            }
        }
    }

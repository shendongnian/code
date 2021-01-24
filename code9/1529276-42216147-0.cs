    SqlCommand komut = new SqlCommand("UPDATE MesaiBilgileri SET Id = @mesaiId, AdiSoyadi =@secilipersonel,Mesai = @cboxSaatMesai, MesaiTarih = @tarih", baglan);
    komut.Parameters.Add("@mesaiId", SqlDbType.Int).Value = mesaiId;
    komut.Parameters.Add("@secilipersonel", SqlDbType.VarChar).Value = secilipersonel;
    komut.Parameters.Add("@cboxSaatMesai", SqlDbType.VarChar).Value = cboxSaatMesai.Text;
    komut.Parameters.Add("@tarih", SqlDbType.DateTime).Value = secilitarih;
   
    komut.ExecuteNonQuery();

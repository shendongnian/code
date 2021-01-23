    MySqlCommand sqlCommand = new MySqlCommand("UPDATE barang SET Nama_barang =@Nama_barang,Jumlah_barang=@Jumlah_barang,Harga_awal=@Harga_awal,Harga_jual=@Harga_jual WHERE ID =@id", con);
    sqlCommand.Parameters.AddWithValue("@Nama_barang", txtNama.Text);
    sqlCommand.Parameters.AddWithValue("@Jumlah_barang", txtStock.Text);
    sqlCommand.Parameters.AddWithValue("@Harga_awal", txtBeli.Text);
    sqlCommand.Parameters.AddWithValue("@Harga_jual", txtJual.Text);
    sqlCommand.Parameters.AddWithValue("@id", txtIndex.Text);
    try
    {
       con.Open();
       sqlCommand.ExecuteNonQuery();
       MessageBox.Show("sukses");
       con.Close();
    }
    catch (Exception ex)
    {
       MessageBox.Show(ex.Message);
    }

    protected void Button_SonucKaydet_Click(object sender, EventArgs e)
    {// I did with Asif.Ali and  Alex Kudryashev's opinion.
        try
        {    
             OleDbConnection con = new OleDbConnection(VTYolu);
             con.Open();
             foreach (GridViewRow row in GridView4.Rows)
             {
                 Label innerLabel = (Label)row.FindControl("Label1x");
                 DropDownList innerDropdown = (DropDownList)row.FindControl("DropDownList1x");
                 TextBox innerTextBox = (TextBox)row.FindControl("TextBox4x");
             
                 string Ekle1 = "UPDATE Dat_Odev SET OdevKontrolTarihi=@Tarih, OdevSonucu=@Sonuc, SonucAciklama=@Aciklama WHERE Kimlik=@id";
                 OleDbCommand Komut1 = new OleDbCommand(Ekle1, con);
                 Komut1.Parameters.AddWithValue("@Tarih", DateTime.Now.ToString());
                 Komut1.Parameters.AddWithValue("@Sonuc", innerDropdown.SelectedValue);
                 Komut1.Parameters.AddWithValue("@Aciklama", innerTextBox.Text);
                 Komut1.Parameters.AddWithValue("@id", Int32.Parse(innerLabel.Text));
                 Komut1.ExecuteNonQuery();
            }
            con.Close();
            GridView1.DataBind();
        }
        catch (Exception HataKodu)
        {//Hata oluştuğunda çalışacak kodlar
            Label_Hata.Visible = true;
            Label_Hata.Text = "Ödev sonuçlarını kaydederken bir hata oluştu. Veya Veritabanı hatası. Sistem yöneticisi ile irtibata geçiniz. (Hata kodu: " + HataKodu + ")";
        }
    }

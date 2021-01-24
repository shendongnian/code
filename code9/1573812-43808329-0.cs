    string Qry1 = "INSERT INTO tbladdbook(fBookTitle,fAuthor,fBookYr,fEdition,fPublication,fAccNo,fCallNo,fCategory,fBarCodeNo,fCurrentCopies) VALUES (@Title, @Author, @BookYr, @Edition, @Publication, @AccNo, @CallNo, @Category, @BarCode, @Copies)";
    string Qry2 = "INSERT INTO tbltruecopies(fBookTitle, fAuthor, fBarCodeNo, fTrueCopies) VALUES (@Title, @Author, @Barcode, @Copies)";
    using (SqlConnection conn = new SqlConnection(connectionstring)) {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand()) {
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Qry2;
            cmd.Parameters.AddWithValue("@Title", txtTITLE.Text);
            cmd.Parameters.AddWithValue("@Author", txTAUTHOR.Text);
            cmd.Parameters.AddWithValue("@Barcode", Int64.parse(txtBARCODE.Text));
            cmd.Parameters.AddWithValue("@Copies", Int64.parse(txtCOPIES.Text));
            try { cmd.ExecuteNonQuery(); }
            catch (Exception) { /* your error handling */ }
            cmd.CommandText = Qry1;
            cmd.Parameters.AddWithValue("@BookYr", txtBOOKYR.Text);
            cmd.Parameters.AddWithValue("@Edition", txtEDITION.Text);
            cmd.Parameters.AddWithValue("@Publication", txtPUBLICATION.Text);
            cmd.Parameters.AddWithValue("@AccNo", txtACCESSNO.Text);
            cmd.Parameters.AddWithValue("@CallNo", txtCALLNO.Text);
            cmd.Parameters.AddWithValue("@Category", txtCATEGORY.SelectedItem);
            try { cmd.ExecuteNonQuery(); }
            catch (Exception) { /* your error handling */ }
        }
        conn.Close();
    }

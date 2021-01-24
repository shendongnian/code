     Dim SQLCON As New SqlConnection(MyDataBaseCon)
     Dim CMD As SqlCommand
     Try
            CMD = New SqlCommand("Insert Into TBLAtach (ID,AtachName,AtachMain,AtachFile,AtachNM,AtachDT,AtachAdres) Values (@ID,@AtachName,@AtachMain,@AtachFile,@AtachNM,@AtachDT,@AtachAdres)", SQLCON)
            SQLCON.Open()
            CMD.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int)).Value = Val(T1.Text)
            CMD.Parameters.Add(New SqlParameter("@AtachName", SqlDbType.Int)).Value = Val(T2.Text)
            CMD.Parameters.Add(New SqlParameter("@AtachMain", SqlDbType.Int)).Value = Val(T3.Text)
            Dim FSTream As New FileStream(OpenFileDialog1.FileName, FileMode.Open, FileAccess.Read)
            Dim BNStream As New BinaryReader(FSTream)
            Dim FAttach() As Byte = BNStream.ReadBytes(BNStream.BaseStream.Length)
            CMD.Parameters.Add(New SqlParameter("@AtachFile", SqlDbType.VarBinary)).Value = FAttach
            CMD.Parameters.Add(New SqlParameter("@AtachNM", SqlDbType.NVarChar, 50)).Value = T5.Text
            CMD.Parameters.Add(New SqlParameter("@AtachDT", SqlDbType.NVarChar, 50)).Value = TD1.Text
            CMD.Parameters.Add(New SqlParameter("@AtachAdres", SqlDbType.NVarChar, 250)).Value = T7.Text
            CMD.ExecuteNonQuery()
            SQLCON.Close()
            FSTream.Close()
            BNStream.Close()
            MsgBox("Ok ", MsgBoxStyle.Information)
            SearchID()
            ClearTxT()
        Catch ex As Exception
            MsgBox(ex.Message)
            SQLCON.Close()
            WaitPic.Visible = False
        End Try
 

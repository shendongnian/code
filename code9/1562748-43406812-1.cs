    conn.Open()
        Try
            Dim ocb As New OracleCommandBuilder
            ocb = New OracleCommandBuilder(da)
            da.Update(ds, "TEST")
            MessageBox.Show("Information Updated")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
        conn.Close()

       Try
            ItDataset.Clear()
            Flt = "Select ID ,  AtachAdres + AtachNM AS 'Fname' , AtachFile from TBLAtach where ID = " & T1.Text & ""
            ItDataset = GeneralDataManager.InquireData(ItDataset, Flt, "TBLAtach")
            If Me.BindingContext(ItDataset, "TBLAtach").Count > 0 Then
                Dim FName As String = ItDataset.Tables("TBLAtach").Rows(0).Item("Fname")
                Dim FAttach() As Byte = CType(ItDataset.Tables("TBLAtach").Rows(0).Item("AtachFile"), Byte())
                Dim FStream As New FileStream(FName.ToString, FileMode.OpenOrCreate, FileAccess.Write)
                FStream.Write(FAttach, 0, (FAttach.Length))
                Process.Start(FName)
                FStream.Close()
            End If
            WaitPic.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

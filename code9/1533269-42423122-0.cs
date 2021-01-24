          Public Class Form1
          Private Sub Form1_Load(sender As Object, e As EventArgs) Handles      MyBase.Load
          ConnectDatabase()
          loadView()
          End Sub
          Private Sub loadView()
        Dim enumerator As IEnumerator = Nothing
        dsOnDesign.Tables(0).Clear()
        Dim dataSetTemp As System.Data.DataSet
        dataSetTemp = New DataSet
        Dim da As New MySqlDataAdapter
        Dim str As String = "SELECT id, name, passed, resultPending FROM mydb.mytable"
        da = New MySqlDataAdapter(str, conn)
        da.Fill(dataSetTemp)
        Try
            enumerator = dataSetTemp.Tables(0).Rows.GetEnumerator()
            While enumerator.MoveNext()
                Dim current As DataRow = DirectCast(enumerator.Current, DataRow)
                Dim i As DataRow = Me.dsOnDesign.Tables(0).NewRow()
                i("ID") = Conversions.ToInteger(current(0))
                i("Name") = current(1).ToString()
                i("Passed") = If(current(2) Is DBNull.Value, False, fbool(CBool(current(2))))
                i("ResultPending") = If(current(3) Is DBNull.Value, False, fbool(CBool(current(3))))
                dsOnDesign.Tables(0).Rows.Add(i)
            End While
        Finally
            If (TypeOf enumerator Is IDisposable) Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        GridControl2.DataSource = dsOnDesign.Tables(0)
        End Sub
          Private Function fbool(ByVal bool As Boolean) As Boolean
           If bool = True Then
              Return True
            Else
              Return False
           End If
         End Function
        End Class

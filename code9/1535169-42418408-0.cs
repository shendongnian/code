    Private Sub dataGridView_MouseClick(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs
        ) Handles Me.MouseClick
        If e.Button = Forms.MouseButtons.Right Then
            Dim m As New Forms.ContextMenu()
            Dim hi As HitTestInfo = Me.HitTest(e.X, e.Y)
            If hi.RowIndex >= 0 Then
                m.MenuItems.Add(New Forms.MenuItem("Insert Line", AddressOf CType(Application.Current.MainWindow, MainWindow).menuFEInsertLine_Click))
            End If
            If hi.ColumnIndex >= 0 Then
                If hi.RowIndex >= 0 Then
                    m.MenuItems.Add("-")
                End If
                m.MenuItems.Add(New Forms.MenuItem("Insert Column", AddressOf CType(Application.Current.MainWindow, MainWindow).menuFEInsertColumn_Click))
            End If
            m.Show(Me, New System.Drawing.Point(e.X, e.Y))
        End If
    End Sub
    Private Sub dataGridView_MouseMove(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs
        ) Handles Me.MouseMove
        Try
            Dim hi As HitTestInfo = Me.HitTest(e.X, e.Y)
            If hi IsNot Nothing Then
                Me.SetCurrentCellAddressCore(hi.ColumnIndex, hi.RowIndex, False, False, False)
            End If
        Catch ex As System.ArgumentOutOfRangeException
        End Try
    End Sub

    Imports WindowsApplication2.Moletrator.SQLDocumentor
    Public Class formSQLInfoEnumeratorDemo
    Private Sub formSQLInfoEnumeratorDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    
    End Sub
    
    Private Sub buttonSQLServerEnumerator_Click(sender As Object, e As EventArgs) Handles buttonSQLServerEnumerator.Click
        GetSQLDetails(Me.listboxSQLServerInstances)
    End Sub
    Private Sub GetSQLDetails(SQLListBox As ListBox)
        Dim sie As New SQLInfoEnumerator()
        Try
            If SQLListBox.Name = "listboxSQLServerDatabaseInstances" Then
                SQLListBox.Items.Clear()
                sie.SQLServer = listboxSQLServerInstances.SelectedItem.ToString()
                sie.Username = textboxUserName.Text
                sie.Password = textboxPassword.Text
                SQLListBox.Items.AddRange(sie.EnumerateSQLServersDatabases())
            Else
                SQLListBox.Items.Clear()
                SQLListBox.Items.AddRange(sie.EnumerateSQLServers())
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    End Class

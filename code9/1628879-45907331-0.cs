    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        IO.File.WriteAllText(IO.Path.GetTempPath & "storedText", TextBox1.Text)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        MessageBox.Show(IO.File.ReadAllText(IO.Path.GetTempPath & "storedText"))
    End Sub

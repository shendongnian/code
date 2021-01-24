    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Software\TextRetriever", "SavedText", TextBox1.Text, Microsoft.Win32.RegistryValueKind.String)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        MessageBox.Show(Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\Software\TextRetriever", "SavedText", ""))
    End Sub

    Public Shared Function Show(caption As String, text As String, button As MessageBoxButton, image As MessageBoxImage) As MessageBoxResult
        _messageBox = New WpfMessageBox()
        _messageBox.Label1.Content = caption
        _messageBox.Label2.Content = text
        Return _result
    End Function

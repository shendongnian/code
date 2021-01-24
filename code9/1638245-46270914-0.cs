    Public Shared Function Show(caption As String, text As String, button As MessageBoxButton, image As MessageBoxImage) As MessageBoxResult
        _messageBox = New WpfMessageBox() With {
            .Label1 = {.Content = caption},
            .Label2 = {.Content = text}
        }
        Return _result
    End Function

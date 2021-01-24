    Public Class EventArgs(Of T)
        Inherits EventArgs
        '...
    End Class
    Public Class ItemAddedEventArgs
        Inherits EventArgs(Of ListViewItem)
        '...
    End Class
    Public Class MyListView
        Inherits ListView
        Public Event ItemAdded As EventHandler(Of ItemAddedEventArgs)
        '...
    End Class

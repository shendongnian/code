    Module Module1
        Sub Main()
            Dim infos As New List(Of info)
            ets = infos.GroupBy(Function(x) x.index).ToDictionary(Function(x) x.Key, Function(y) y.FirstOrDefault())
        End Sub
        Public ets As New Dictionary(Of Integer, info)
        Public Class info
            Public Property index As Integer
            Public Property imglst_index As Integer
        End Class
    End Module

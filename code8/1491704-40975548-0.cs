    Public Class ViewModel
    Public Sub New()
        EmpDetails = New List(Of EmpDetail)
        EmpDetails.Add(New EmpDetail With {.ColumnA = "A1", .ColumnB = "B1"})
        EmpDetails.Add(New EmpDetail With {.ColumnA = "A2", .ColumnB = "B2"})
    End Sub
    Public Property EmpDetails As List(Of EmpDetail)
    End Class

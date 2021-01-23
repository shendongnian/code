    Public Class ViewModel
    Public Sub New()
        EmpDetails = New List(Of EmployeeDetails)
        EmpDetails.Add(New EmployeeDetails With {.ColumnA = "A1", .ColumnB = "B1"})
        EmpDetails.Add(New EmployeeDetails With {.ColumnA = "A2", .ColumnB = "B2"})
    End Sub
    Public Property EmpDetails As ObservableCollection(Of EmployeeDetails)
    End Class

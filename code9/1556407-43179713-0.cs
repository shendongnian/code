    Public Class TestRecord
    Private _RecordsID As Integer
    Private _Name As String
    Public Property RecordsID As Integer
        Get
            Return _RecordsID
        End Get
        Set(value As Integer)
            _RecordsID = value
        End Set
    End Property
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property

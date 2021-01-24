    Option Explicit On
    Imports System
    Imports System.Data.SqlClient
    Public Module DataAccess
    Public m_sConnectionString As String = "Server=sql01; Database=test; uid=myuser; pwd=mypwd;"
    Private m_oConnection As SqlConnection = New SqlConnection
    Private m_oTransaction As SqlTransaction
    Public Function OpenDB() As Boolean
        Try
            m_oConnection = New SqlConnection
            m_oConnection.ConnectionString = m_sConnectionString
            m_oConnection.Open()
            Return True
        Catch sqlex As SqlException
            Console.WriteLine(sqlex.Message)
            Return False
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return False
        End Try
    End Function
    Public Sub CloseDB()
        Try
            m_oTransaction = Nothing
            m_oConnection.Close()
            m_oConnection = Nothing
        Catch sqlex As SqlException
            Console.WriteLine(sqlex.Message)
            Stop
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Stop
        Finally
        End Try
    End Sub
    Public Sub CommitTransaction()
        Try
            If m_oTransaction IsNot Nothing Then m_oTransaction.Commit()
        Catch sqlex As SqlException
            Console.WriteLine(sqlex.Message)
            Stop
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Stop
        Finally
            m_oTransaction = Nothing
        End Try
    End Sub
    Public Sub AbortTransaction()
        Try
            If m_oTransaction IsNot Nothing Then m_oTransaction.Rollback()
        Catch sqlex As SqlException
            Console.WriteLine(sqlex.Message)
            Stop
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Stop
        Finally
            m_oTransaction = Nothing
        End Try
    End Sub
    Public Function ReadRecordByID(ID As Integer, LockRecord As Boolean) As Tuple(Of Boolean, DataRow)
        Dim Result As Tuple(Of Boolean, DataRow) = New Tuple(Of Boolean, DataRow)(False, Nothing)
        If ID = 0 Then Return Result
        Dim sSQL As String = ""
        Dim oCommand As SqlCommand = Nothing
        Dim LockCommand As String = ""
        Dim MyDA As SqlDataAdapter
        Dim MyTable As DataTable
        Dim MyRow As DataRow
        Try
            m_oTransaction = Nothing
            oCommand = m_oConnection.CreateCommand
            If LockRecord Then
                m_oTransaction = m_oConnection.BeginTransaction(IsolationLevel.Serializable)
                LockCommand = "WITH (HOLDLOCK, UPDLOCK) "
            End If
            sSQL = ""
            sSQL &= "SELECT * FROM TempStock " & LockCommand & "WHERE StockID = " & ID
            oCommand.CommandText = sSQL
            oCommand.Connection = m_oConnection
            MyDA = New SqlDataAdapter
            MyTable = New DataTable
            If LockRecord Then oCommand.Transaction = m_oTransaction
            MyDA.SelectCommand = oCommand
            MyDA.Fill(MyTable)
            MyRow = MyTable.Rows(0)
            Result = New Tuple(Of Boolean, DataRow)(True, MyRow)
            MyTable = Nothing
            MyDA = Nothing
        Catch sqlex As SqlException
            Console.WriteLine(sqlex.Message)
            If m_oTransaction IsNot Nothing Then AbortTransaction()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            If m_oTransaction IsNot Nothing Then AbortTransaction()
        Finally
        End Try
        Return Result
    End Function
    Public Function UpdateRecord(Row As DataRow) As Boolean
        Dim Result As Boolean = False
        Dim sSQL As String = ""
        Dim oCommand As SqlCommand = Nothing
        Try
            oCommand = m_oConnection.CreateCommand
            sSQL = ""
            sSQL &= "UPDATE TempStock " & vbCrLf
            sSQL &= "SET Quantity = " & Row("Quantity") & ", Allocated = " & Row("Allocated") & ", LastUpdated = GETDATE() WHERE StockID = " & Row("StockID")
            oCommand.CommandText = sSQL
            oCommand.Connection = m_oConnection
            oCommand.Transaction = m_oTransaction
            oCommand.ExecuteNonQuery()
            Result = True
        Catch sqlex As SqlException
            Console.WriteLine(sqlex.Message)
            If m_oTransaction IsNot Nothing Then AbortTransaction()
            Result = False
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            If m_oTransaction IsNot Nothing Then AbortTransaction()
            Result = False
        End Try
        Return Result
    End Function
    End Module

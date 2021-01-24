    Imports System.Runtime.InteropServices
    Imports System.Text
    Namespace Moletrator.SQLDocumentor
    
    Public Class SQLInfoEnumerator
        <DllImport("odbc32.dll")> _
        Private Shared Function SQLAllocHandle(handleType As Short, inputHandle As IntPtr, ByRef outputHandlePtr As IntPtr) As Short
        End Function
        <DllImport("odbc32.dll")> _
        Private Shared Function SQLSetEnvAttr(environmentHandle As IntPtr, attribute As Integer, valuePtr As IntPtr, stringLength As Integer) As Short
        End Function
        <DllImport("odbc32.dll")> _
        Private Shared Function SQLFreeHandle(hType As Short, Handle As IntPtr) As Short
        End Function
        <DllImport("odbc32.dll", CharSet:=CharSet.Ansi)> _
        Private Shared Function SQLBrowseConnect(handleConnection As IntPtr, inConnection As StringBuilder, stringLength As Short, outConnection As StringBuilder, bufferLength As Short, ByRef stringLength2Ptr As Short) As Short
        End Function
        Private Const SQL_DRIVER_STR As String = "DRIVER=SQL SERVER"
        Private Const SQL_SUCCESS As Short = 0
        Private Const SQL_HANDLE_ENV As Short = 1
        Private Const SQL_HANDLE_DBC As Short = 2
        Private Const SQL_ATTR_ODBC_VERSION As Integer = 200
        Private Const SQL_OV_ODBC3 As Integer = 3
        Private Const SQL_NEED_DATA As Short = 99
        Private Const DEFAULT_RESULT_SIZE As Short = 1024
        Private Const START_STR As String = "{"
        Private Const END_STR As String = "}"
        ''' <summary>
        ''' A string to hold the selected SQL Server
        ''' </summary>
        Private m_SQLServer As String
        ''' <summary>
        ''' A string to hold the username
        ''' </summary>
        Private m_Username As String
        ''' <summary>
        ''' A string to hold the password
        ''' </summary>
        Private m_Password As String
        ''' <summary>
        ''' Property to set the SQL Server instance
        ''' </summary>
        Public WriteOnly Property SQLServer() As String
            Set(value As String)
                m_SQLServer = value
            End Set
        End Property
        ''' <summary>
        ''' Property to set the Username
        ''' </summary>
        Public WriteOnly Property Username() As String
            Set(value As String)
                m_Username = value
            End Set
        End Property
        ''' <summary>
        ''' Property to set the Password
        ''' </summary>
        Public WriteOnly Property Password() As String
            Set(value As String)
                m_Password = value
            End Set
        End Property
        ''' <summary>
        ''' Enumerate the SQL Servers returning a list (if any exist)
        ''' </summary>
        ''' <returns></returns>
        Public Function EnumerateSQLServers() As String()
            Return RetrieveInformation(SQL_DRIVER_STR)
        End Function
        ''' <summary>
        ''' Enumerate the specified SQL server returning a list of databases (if any exist)
        ''' </summary>
        ''' <returns></returns>
        Public Function EnumerateSQLServersDatabases() As String()
            Return RetrieveInformation(Convert.ToString((Convert.ToString((Convert.ToString(SQL_DRIVER_STR & Convert.ToString(";SERVER=")) & m_SQLServer) + ";UID=") & m_Username) + ";PWD=") & m_Password)
        End Function
        ''' <summary>
        ''' Enumerate for SQLServer/Databases based on the passed information it the string
        ''' The more information provided to SQLBrowseConnect the more granular it gets so
        ''' if only DRIVER=SQL SERVER passed then a list of all SQL Servers is returned
        ''' If DRIVER=SQL SERVER;Server=ServerName is passed then a list of all Databases on the
        ''' servers is returned etc
        ''' </summary>
        ''' <param name="InputParam">A valid string to query for</param>
        ''' <returns></returns>
        Private Function RetrieveInformation(InputParam As String) As String()
            Dim m_environmentHandle As IntPtr = IntPtr.Zero
            Dim m_connectionHandle As IntPtr = IntPtr.Zero
            Dim inConnection As New StringBuilder(InputParam)
            Dim stringLength As Short = CShort(inConnection.Length)
            Dim outConnection As New StringBuilder(DEFAULT_RESULT_SIZE)
            Dim stringLength2Ptr As Short = 0
            Try
                If SQL_SUCCESS = SQLAllocHandle(SQL_HANDLE_ENV, m_environmentHandle, m_environmentHandle) Then
                    If SQL_SUCCESS = SQLSetEnvAttr(m_environmentHandle, SQL_ATTR_ODBC_VERSION, New IntPtr(SQL_OV_ODBC3), 0) Then
                        If SQL_SUCCESS = SQLAllocHandle(SQL_HANDLE_DBC, m_environmentHandle, m_connectionHandle) Then
                            If SQL_NEED_DATA = SQLBrowseConnect(m_connectionHandle, inConnection, stringLength, outConnection, DEFAULT_RESULT_SIZE, stringLength2Ptr) Then
                                If SQL_NEED_DATA <> SQLBrowseConnect(m_connectionHandle, inConnection, stringLength, outConnection, DEFAULT_RESULT_SIZE, stringLength2Ptr) Then
                                    Throw New ApplicationException("No Data Returned.")
                                End If
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw New ApplicationException("Cannot Locate SQL Server.")
            Finally
                FreeConnection(m_connectionHandle)
                FreeConnection(m_environmentHandle)
            End Try
            If outConnection.ToString() <> "" Then
                Return ParseSQLOutConnection(outConnection.ToString())
            Else
                Return Nothing
            End If
        End Function
        ''' <summary>
        ''' Parse an outConnection string returned from SQLBrowseConnect
        ''' </summary>
        ''' <param name="outConnection">string to parse</param>
        ''' <returns></returns>
        Private Function ParseSQLOutConnection(outConnection As String) As String()
            Dim m_Start As Integer = outConnection.IndexOf(START_STR) + 1
            Dim m_lenString As Integer = outConnection.IndexOf(END_STR) - m_Start
            If (m_Start > 0) AndAlso (m_lenString > 0) Then
                outConnection = outConnection.Substring(m_Start, m_lenString)
            Else
                outConnection = String.Empty
            End If
            Return outConnection.Split(",".ToCharArray())
        End Function
        Private Sub FreeConnection(handleToFree As IntPtr)
            If handleToFree <> IntPtr.Zero Then
                SQLFreeHandle(SQL_HANDLE_DBC, handleToFree)
            End If
        End Sub
    End Class
    End Namespace

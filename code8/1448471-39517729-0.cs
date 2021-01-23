	Imports System.Data.OleDb
		Dim provider As String
		Dim dataFile As String
		Dim connString As String
		
		Public myConnection As OleDbConnection = New OleDbConnection
		
		Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
		dataFile = "pathto.accdb"
		connString = provider & dataFile
		myConnection.ConnectionString = connString
		End Sub
		
		Private Sub NextSub()
		
			str = "sql statement;"
			Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
			dr = cmd.ExecuteReader
			While dr.Read()
               'do stuff with teh reader
			End While
			myConnection.Close()
		End Sub

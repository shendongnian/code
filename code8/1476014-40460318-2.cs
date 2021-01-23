    Public Class ScriptMain
    Inherits UserComponent
    Private columns As Integer()
    Public Overrides Sub PreExecute()
    Dim input As IDTSInput90 = ComponentMetaData.InputCollection(0)
    ReDim columns(input.InputColumnCollection.Count)
    columns = Me.GetColumnIndexes(input.ID)
     System.Windows.Forms.MessageBox.Show(columns.Length.ToString())
    End Sub
    Public Overrides Sub ProcessInput(ByVal InputID As Integer, ByVal Buffer As Microsoft.SqlServer.Dts.Pipeline.PipelineBuffer)
 
    While Buffer.NextRow()
    Dim values As New System.Text.StringBuilder
    For Each index As Integer In columns
    Dim value As Object = Buffer(index)
    'If value Is Not Nothing Then
    values.Append(value)
    'End If
    values.Append(",")
    Next
    '' TODO: Write line to destination here
    System.Windows.Forms.MessageBox.Show(values.ToString())
    End While
    End Sub
    End Class

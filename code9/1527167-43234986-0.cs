    Public Sub Main()
        Dim oMissing As Object = System.Reflection.Missing.Value
        Dim xl As New Microsoft.Office.Interop.Excel.ApplicationClass()
        Dim xlBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim laPath As String = "C:\Filename.xls"
        xlBook = DirectCast(xl.Workbooks.Open(laPath, oMissing, oMissing, oMissing, oMissing, oMissing,
        oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
        oMissing, oMissing, oMissing), Workbook)
        xlSheet = DirectCast(xlBook.Worksheets.Item(1), Worksheet)
        xlBook.SaveAs("C:\Filename.txt", XlFileFormat.xlUnicodeText, oMissing, oMissing, oMissing, oMissing,, oMissing, oMissing, oMissing, oMissing, oMissing)
        xl.Application.Workbooks.Close()
        Dts.TaskResult = ScriptResults.Success
    End Sub

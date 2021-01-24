    Public WithEvents decideList As Microsoft.Office.Tools.Excel.ListObject
    Public dt As System.Data.DataTable = New System.Data.DataTable("MasterData")
    ' Load data into the datatable dt
    
    Dim worksheet As Microsoft.Office.Tools.Excel.Worksheet = Globals.Factory.GetVstoObject(sheet) 'where sheet is the native worksheet where you are locating the ListObject
    Dim cell As Excel.Range = worksheet.Range("$A$1:$D$4")
    
    decideList = worksheet.Controls.AddListObject(cell, "decideList")
    decideList.AutoSetDataBoundColumnHeaders = True
    decideList.SetDataBinding(dt, Nothing, { "FirstName", "LastName", "Company" })

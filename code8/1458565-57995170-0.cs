 c#
Microsoft.Office.Interop.Excel.Sheets TestWorksheets = TestBook.Worksheets;
if (TestWorksheets.Count > NumberofsheetsIWantToKeep)
{
    int WorkSheetCounter = TestWorksheets.Count;
    while (WorkSheetCounter > NumberofsheetsIWantToKeep)
    {
        if(TestWorksheets[WorkSheetCounter].Name.Contains("blah"))
        {
            if(TestWorksheets[WorkSheetCounter].Visible == Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVeryHidden)
		    { TestWorksheets[WorkSheetCounter].Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetHidden; }
            TestWorksheets[WorkSheetCounter].Delete();
        }
        WorkSheetCounter--;
    }
}

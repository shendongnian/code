Building on Rafatic's answer (second problem - accessing the document), I found I was able to access the worksheet with the below code. I mention this because Globals.ThisAddIn.Application.ActiveDocument didn't seem to exist.
    //using System.Windows.Forms;
    //using Excel = Microsoft.Office.Interop.Excel;
    Excel.Worksheet xlWb = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet;
    MessageBox.Show(xlWb.Name);
    xlWb.Range["A1"].Value = "Hello World!";

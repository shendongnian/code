    public partial class Form1 : Form
    {
      string[] zip;
      string[] place;
      public Form1()
      {
        InitializeComponent();
      }
      private void Form1_Load(object sender, EventArgs e)
      {
        Excel.Application objExcel = new Excel.Application();
        Excel.Workbook objWorkbook = objExcel.Workbooks.Open(@"C:\Users\John\Desktop\cs\TestExcel2_3000.xlsx");
        Excel.Worksheet objWorksheet = objWorkbook.Worksheets["Tabelle1"];
        
        zip = ReadSheet(objWorksheet);
        objWorkbook.Close();
        Excel.Workbook objWorkbook1 = objExcel.Workbooks.Open(@"C:\Users\John\Desktop\cs\TestExcel3_3000.xlsx");
        Excel.Worksheet objWorksheet1 = objWorkbook1.Worksheets["Tabelle1"];
         
        place = ReadSheet(objWorksheet1);
        objWorkbook1.Close();
        objExcel.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(objWorkbook);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(objWorkbook1);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel);
      }
      private string[] ReadSheet(Excel.Worksheet inSheet)
      {
        Excel.Range targetCells = inSheet.UsedRange;
        //Excel.Range targetCells = inSheet.Range["A1:A3000"];
        Array allValues = (Array)targetCells.Cells.Value;
        return allValues.Cast<string>().ToArray();
      }
    }

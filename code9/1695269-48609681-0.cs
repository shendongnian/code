    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Excel = Microsoft.Office.Interop.Excel;
    using Office = Microsoft.Office.Core;
    using Microsoft.Office.Tools.Excel;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Excel;
    namespace ExcelAddIn1
    {
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
        }
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        public void Calc(Range dataRange)
        {
            dataRange.Calculate();
        }
        public void SetSource()
        {
            Excel.Worksheet ws = Application.ActiveSheet as Excel.Worksheet;
            Excel.Range c1 = ws.Cells[1, 1];
            Excel.Range c2 = ws.Cells[10, 1];
            var oRangeSource = (Excel.Range)ws.get_Range(c1, c2);
            for (int i = 1; i <= 10; i++)
            {
                oRangeSource.Cells[i, 1].Value = i;
            }
        }
        public Excel.Range GetTestCells()
        {
            Excel.Worksheet ws = Application.ActiveSheet as Excel.Worksheet;
            Excel.Range c1 = ws.Cells[1, 2];
            Excel.Range c2 = ws.Cells[10, 2];
            //Get the range using number index
            var oRange = (Excel.Range)ws.get_Range(c1, c2);
            return oRange;
        }
        public static void SetFormulasCellwise(Range dataRange,IEnumerable<string> columnFormulas,int columnIndex)
        {
            var rowIndex = 0;
            foreach (var columnFormula in columnFormulas)
            {
                var dataColumnCell = dataRange.Cells[rowIndex+1 , columnIndex];
                try
                {
                    dataColumnCell.FormulaLocal = columnFormula;
                }
                catch (COMException)
                {
                    MessageBox.Show("Failed to set column formula\n"
                                    + columnFormula + "\n" +
                                    "to row " + (rowIndex + 1) + " and column "
                                    + (columnIndex + 1) + ".\n" +
                                    "Please make sure the formula is valid\n" +
                                    "and that the workbook is writable.",
                        "Error");
                    throw;
                }
                rowIndex++;
            }
        }
        public static void SetFormulasColumnwise(Range dataRange, int columnIndex, IReadOnlyCollection<string> columnFormulas)
        {
            var columnNumber = columnIndex;
            var dataColumnCell = dataRange;
            var columnFormulas2Dimensional = ToColumn2DimensionalArray(columnFormulas);
            try
            {
                dataRange.FormulaLocal = columnFormulas2Dimensional[0,0];
            }
            catch (COMException)
            {
                MessageBox.Show("Failed to set column formulas "
                                + "to column " + columnNumber + ".\n" +
                                "Please make sure the formula is valid\n" +
                                "and that the workbook is writable.",
                    "Error");
                throw;
            }
        }
        public static string[,] ToColumn2DimensionalArray(IReadOnlyCollection<string> columnFormulas)
        {
            var columnFormulas2Dimensional = new string[columnFormulas.Count, 1];
            var columnFormulasIndex = 0;
            foreach (var columnFormula in columnFormulas)
            {
                columnFormulas2Dimensional[columnFormulasIndex, 0] = columnFormula;
                columnFormulasIndex++;
            }
            return columnFormulas2Dimensional;
        }
        #region Code généré par VSTO
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        #endregion
    }

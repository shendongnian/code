    using Microsoft.Office.Interop.Excel;  
      
    void CreateChart()
    {
        ChartData gChartData;
        Workbook gWorkBook;
        Worksheet gWorkSheet;
        //  Create the chart and set a reference to the chart data.
        var myChart = ActivePresentation.Slides[1].Shapes.AddChart() as Microsoft.Office.Interop.PowerPoint.Chart;
        gChartData = myChart.ChartData;
        //  Set the Workbook and Worksheet references.
        gWorkBook = gChartData.Workbook;
        gWorkSheet = gWorkBook.Worksheets[1];
        //  Add the data to the workbook.
        gWorkSheet.ListObjects["Table1"].Resize(gWorkSheet.Range["A1:B5"]);
        gWorkSheet.Range["Table1[[#Headers],[Series 1]]"].Value = "Items";
        gWorkSheet.Range["a2"].Value = "Coffee";
        gWorkSheet.Range["a3"].Value = "Soda";
        gWorkSheet.Range["a4"].Value = "Tea";
        gWorkSheet.Range["a5"].Value = "Water";
        gWorkSheet.Range["b2"].Value = "1000";
        gWorkSheet.Range["b3"].Value = "2500";
        gWorkSheet.Range["b4"].Value = "4000";
        gWorkSheet.Range["b5"].Value = "3000";
        //ToDo: Style
    }

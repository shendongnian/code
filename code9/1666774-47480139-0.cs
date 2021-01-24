            var results = GetResultsSomehow();
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Reading Ages");
            workSheet.TabColor = System.Drawing.Color.Black;
            var scatterChart = (ExcelScatterChart)workSheet.Drawings.AddChart("Reading Ages", eChartType.XYScatterSmooth);
            scatterChart.SetPosition(3, 1, 4, 1);
            scatterChart.SetSize(800, 500);
            scatterChart.XAxis.Format = "dd/mm/yyyy";
            // must display hidden data and empty as gaps, otherwise the date axis will explode 
            scatterChart.ShowHiddenData = true;
            scatterChart.DisplayBlanksAs = eDisplayBlanksAs.Gap;
            int rowIndex = 4;
            int stopIndex = 4;
            foreach (var student in results.Select(a=> a.Student).Distinct())
            {
                int start = rowIndex;
                int stop = start + stopIndex;
                workSheet.Cells[rowIndex, 1].Value = student.Surname;
                foreach(var row in results.Where(a=> a.Student == student))
                {
                    workSheet.Cells[rowIndex, 2].Value = row.Age;
                    workSheet.Cells[rowIndex, 3].Value = row.Date;
                    
                    rowIndex++;
                    stopIndex++;
                }
                stop = rowIndex;
                var series = scatterChart.Series.Add(workSheet.Cells[start, 2, stop - 1, 2], workSheet.Cells[start, 3, stop - 1, 3]);
                series.Header = student.Surname;           
            }
            
            string excelName = identifier + " reading ages";
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=" + excelName + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }

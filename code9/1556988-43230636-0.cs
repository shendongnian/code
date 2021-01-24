                 //Nbre documents différents
                Microsoft.Office.Interop.Excel.ChartObject chartObjectnbdd = sheet.ChartObjects().Add((float)sheet.get_Range("E1").Left, (float)sheet.get_Range("B" + (Row + 2).ToString()).Top, 300, 300);
                chartObjectnbex.Chart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlBarClustered;
                chartObjectnbdd.Chart.HasTitle = true;
                chartObjectnbdd.Chart.ChartTitle.Text = "Nombre de documents différents";
                Microsoft.Office.Interop.Excel.SeriesCollection seriescollnbdd = chartObjectnbdd.Chart.SeriesCollection();
                Microsoft.Office.Interop.Excel.Series seriesnbdd = null;
                i = 2;
                while (i <= Row)
                {
                    seriesnbdd = seriescollnbdd.NewSeries();
                    seriesnbdd.Name = excel.Cells[i, 1].Value.ToString();
                    seriesnbdd.Values = sheet.Range["C" + i.ToString() + ":C" + i.ToString()];
                    i++;
                }

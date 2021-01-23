        //Add in excel Chart for results
            Excel.Range oRng = Sheet.get_Range("B2", "B11"); 
            Excel.Chart ct = Sheet.Shapes.AddChart().Chart;
            var missing = System.Type.Missing;
            ct.ChartWizard(oRng, Excel.XlChartType.xlXYScatterSmooth, missing, missing, missing, missing, missing, missing, "x axis", missing, missing);
            Excel.Series oSeries = (Excel.Series)ct.SeriesCollection(1);
            oSeries.XValues = Sheet.get_Range("A3", "A11");
            if (datatable.Checked)
            {
                ct.ChartWizard(Source: "A2:B11",
                   Title: "mRem/hr from gamma radiation",
                   CategoryTitle: "Minutes After Run",
                   ValueTitle: "mRem/hr");
                ct.Refresh();
            }
            if (datatablelong.Checked)
            {
                ct.ChartWizard(Source: "A2:B11",
                   Title: "mRem/hr from gamma radiation",
                   CategoryTitle: "Days After Run",
                   ValueTitle: "mRem/hr");
                ct.Refresh();
            }

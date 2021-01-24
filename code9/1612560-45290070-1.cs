        private static void InsertChartInSpreadsheet(SpreadsheetDocument document, string title, Dictionary<string, int> data)
        {
            WorksheetPart graphWorksheetPart = (WorksheetPart)document.WorkbookPart.AddNewPart<WorksheetPart>();
            graphWorksheetPart.Worksheet = new Worksheet(new SheetData());
            Sheets sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>() ;
            Sheet sheet = new Sheet()
            {
                Id = document.WorkbookPart.GetIdOfPart(graphWorksheetPart),
                SheetId = 2,
                Name = "Graph"
            };
            sheets.Append(sheet);
            // Add a new drawing to the worksheet.
            DrawingsPart drawingsPart = graphWorksheetPart.AddNewPart<DrawingsPart>();
            graphWorksheetPart.Worksheet.Append(new DocumentFormat.OpenXml.Spreadsheet.Drawing()
            { Id = graphWorksheetPart.GetIdOfPart(drawingsPart) });
            graphWorksheetPart.Worksheet.Save();
            // Add a new chart and set the chart language to English-US.
            ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
            chartPart.ChartSpace = new ChartSpace();
            chartPart.ChartSpace.Append(new EditingLanguage() { Val = new StringValue("en-US") });
            DocumentFormat.OpenXml.Drawing.Charts.Chart chart = chartPart.ChartSpace.AppendChild<DocumentFormat.OpenXml.Drawing.Charts.Chart>(
                new DocumentFormat.OpenXml.Drawing.Charts.Chart());
            // Create a new clustered column chart.
            PlotArea plotArea = chart.AppendChild<PlotArea>(new PlotArea());
            Layout layout = plotArea.AppendChild<Layout>(new Layout());
            BarChart barChart = plotArea.AppendChild<BarChart>(new BarChart(new BarDirection()
            { Val = new EnumValue<BarDirectionValues>(BarDirectionValues.Column) },
                new BarGrouping() { Val = new EnumValue<BarGroupingValues>(BarGroupingValues.Clustered) }));
            uint i = 0;
            // Iterate through each key in the Dictionary collection and add the key to the chart Series
            // and add the corresponding value to the chart Values.
            foreach (string key in data.Keys)
            {
                BarChartSeries barChartSeries = barChart.AppendChild<BarChartSeries>(new BarChartSeries(new Index()
                {
                    Val =
     new UInt32Value(i)
                },
                    new Order() { Val = new UInt32Value(i) },
                    new SeriesText(new NumericValue() { Text = key })));
                StringLiteral strLit = barChartSeries.AppendChild<CategoryAxisData>(new CategoryAxisData()).AppendChild<StringLiteral>(new StringLiteral());
                strLit.Append(new PointCount() { Val = new UInt32Value(1U) });
                strLit.AppendChild<StringPoint>(new StringPoint() { Index = new UInt32Value(0U) }).Append(new NumericValue(title));
                NumberLiteral numLit = barChartSeries.AppendChild<DocumentFormat.OpenXml.Drawing.Charts.Values>(
                    new DocumentFormat.OpenXml.Drawing.Charts.Values()).AppendChild<NumberLiteral>(new NumberLiteral());
                numLit.Append(new FormatCode("General"));
                numLit.Append(new PointCount() { Val = new UInt32Value(1U) });
                numLit.AppendChild<NumericPoint>(new NumericPoint() { Index = new UInt32Value(0u) }).Append
    (new NumericValue(data[key].ToString()));
                i++;
            }
            barChart.Append(new AxisId() { Val = new UInt32Value(48650112u) });
            barChart.Append(new AxisId() { Val = new UInt32Value(48672768u) });
            // Add the Category Axis.
            CategoryAxis catAx = plotArea.AppendChild<CategoryAxis>(new CategoryAxis(new AxisId()
            { Val = new UInt32Value(48650112u) }, new Scaling(new DocumentFormat.OpenXml.Drawing.Charts.Orientation()
            {
                Val = new EnumValue<DocumentFormat.
    OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax)
            }),
                //START NEW CODE
                new Delete() {Val = false},
                //END NEW CODE
                new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Bottom) },
                //START NEW CODE
                new NumberingFormat() {FormatCode = "General", SourceLinked = false},
                new MajorTickMark() {Val = TickMarkValues.Outside},
                new MinorTickMark() {Val = TickMarkValues.Cross},
                //END NEW CODE
                new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                new CrossingAxis() { Val = new UInt32Value(48672768U) },
                new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                new AutoLabeled() { Val = new BooleanValue(true) },
                new LabelAlignment() { Val = new EnumValue<LabelAlignmentValues>(LabelAlignmentValues.Center) },
                new LabelOffset() { Val = new UInt16Value((ushort)100) },
                //START NEW CODE
                new NoMultiLevelLabels() {Val = true}
                //END NEW CODE
                ));
            // Add the Value Axis.
            ValueAxis valAx = plotArea.AppendChild<ValueAxis>(new ValueAxis(new AxisId() { Val = new UInt32Value(48672768u) },
                new Scaling(new DocumentFormat.OpenXml.Drawing.Charts.Orientation()
                {
                    Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(
                    DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax)
                }),
                //START NEW CODE
                new Delete() {Val = false},
                //END NEW CODE
                new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Left) },
                new MajorGridlines(),
                new DocumentFormat.OpenXml.Drawing.Charts.NumberingFormat()
                {
                    FormatCode = new StringValue("General"),
                    SourceLinked = new BooleanValue(true)
                },
                //START NEW CODE
                    new MajorTickMark() {Val = TickMarkValues.Outside},
                    new MinorTickMark() {Val = TickMarkValues.Cross},
                //END NEW CODE
                new TickLabelPosition()
                {
                    Val = new EnumValue<TickLabelPositionValues>
    (TickLabelPositionValues.NextTo)
                }, new CrossingAxis() { Val = new UInt32Value(48650112U) },
                new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                new CrossBetween() { Val = new EnumValue<CrossBetweenValues>(CrossBetweenValues.Between) }));
            // Add the chart Legend.
            Legend legend = chart.AppendChild<Legend>(new Legend(new LegendPosition() { Val = new EnumValue<LegendPositionValues>(LegendPositionValues.Right) },
                new Layout()));
            chart.Append(new PlotVisibleOnly() { Val = new BooleanValue(true) });
            // Save the chart part.
            chartPart.ChartSpace.Save();
            // Position the chart on the worksheet using a TwoCellAnchor object.
            drawingsPart.WorksheetDrawing = new WorksheetDrawing();
            TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild<TwoCellAnchor>(new TwoCellAnchor());
            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(new ColumnId("1"),
                new ColumnOffset("581025"),
                new RowId("1"),
                new RowOffset("114300")));
            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(new ColumnId("9"),
                new ColumnOffset("276225"),
                new RowId("16"),
                new RowOffset("0")));
            // Append a GraphicFrame to the TwoCellAnchor object.
            DocumentFormat.OpenXml.Drawing.Spreadsheet.GraphicFrame graphicFrame =
                twoCellAnchor.AppendChild<DocumentFormat.OpenXml.
    Drawing.Spreadsheet.GraphicFrame>(new DocumentFormat.OpenXml.Drawing.
    Spreadsheet.GraphicFrame());
            graphicFrame.Macro = "";
            graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualGraphicFrameProperties(
                new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualDrawingProperties() { Id = new UInt32Value(2u), Name = "Chart 1" },
                new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualGraphicFrameDrawingProperties()));
            graphicFrame.Append(new Transform(new Offset() { X = 0L, Y = 0L },
                                                                    new Extents() { Cx = 0L, Cy = 0L }));
            graphicFrame.Append(new Graphic(new GraphicData(new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) })
            { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }));
            twoCellAnchor.Append(new ClientData());
            // Save the WorksheetDrawing object.
            drawingsPart.WorksheetDrawing.Save();
        }

		private void button1_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 100000; i++)
			{
				using (NChartControl chartControl = new NChartControl())
				{
					// set a chart title
					NLabel title = chartControl.Labels.AddHeader("2D Line Chart");
					// setup chart
					NCartesianChart chart = new NCartesianChart();
					chartControl.Panels.Add(chart);
					chart.DockMode = PanelDockMode.Fill;
					chart.Margins = new NMarginsL(2, 0, 2, 2);
					chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
					chart.LightModel.EnableLighting = false;
					chart.Axis(StandardAxis.Depth).Visible = false;
					chart.Wall(ChartWallType.Floor).Visible = false;
					chart.Wall(ChartWallType.Left).Visible = false;
					chart.BoundsMode = BoundsMode.Stretch;
					chart.Height = 40;
					chart.RangeSelections.Add(new NRangeSelection());
					chart.Axis(StandardAxis.PrimaryX).ScrollBar.Visible = true;
					chart.Axis(StandardAxis.PrimaryY).ScrollBar.Visible = true;
					// setup the line series
					NLineSeries line = (NLineSeries)chart.Series.Add(SeriesType.Line);
					//line.Values.FillRandom(new Random(), 10);
				
					line.DataLabelStyle.Visible = false;
					line.Legend.Mode = SeriesLegendMode.DataPoints;
					line.ShadowStyle.Type = ShadowType.GaussianBlur;
					line.ShadowStyle.Offset = new NPointL(new NLength(3, NGraphicsUnit.Pixel), new NLength(3, NGraphicsUnit.Pixel));
					line.ShadowStyle.FadeLength = new NLength(5, NGraphicsUnit.Pixel);
					line.ShadowStyle.Color = System.Drawing.Color.FromArgb(55, 0, 0, 0);
					line.LineSegmentShape = LineSegmentShape.Line;
					chartControl.Controller.Tools.Add(new NSelectorTool());
					chartControl.Controller.Tools.Add(new NAxisScrollTool());
					chartControl.Controller.Tools.Add(new NDataZoomTool());
					NDataPanTool dpt = new NDataPanTool();
					chartControl.Controller.Tools.Add(dpt);
					chartControl.Legends.Clear();
					chartControl.Refresh();
				}
			}
		}

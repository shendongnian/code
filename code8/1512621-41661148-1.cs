	class Plot
	{
		public Plot() { }
		public void DoPlot(List<Read> rrList, ComboBox xBox, ComboBox yBox, Chart chart) //***
		{
			int indX = xBox.SelectedIndex;
			int indY = yBox.SelectedIndex;
			chart.Series.Clear(); //ensure that the chart is empty
			chart.Legends.Clear();
			Legend myLegend = chart.Legends.Add("myLegend");
			myLegend.Title = "myTitle";
			Color[] colors = new Color[] { Color.Blue, Color.Red, Color.Green, Color.Gold }; //***
			int i = 0;
			foreach (Read rr in rrList)
			{
				float[,] data = rr.get_Data();
				int nLines = rr.get_nLines();
				int nColumns = rr.get_nColumns();
				string[] header = rr.get_Header();
				
				chart.Series.Add("Series" + i);
				chart.Series[i].ChartType = SeriesChartType.Line;
				chart.Series[i].LegendText = rr.fileName;
				chart.ChartAreas[0].AxisX.LabelStyle.Format = "{F2}";
				chart.ChartAreas[0].AxisX.Title = header[indX];
				chart.ChartAreas[0].AxisY.Title = header[indY];
				string curSection = rr.section[0];
				int iSection = 0;
				for (int j = 0; j < nLines; j++)
				{
					int k = chart.Series[i].Points.AddXY(data[j, indX], data[j, indY]);
					if (rr.section[j] != curSection) //section changed
					{
						curSection = rr.section[j];
						iSection++;
					}
					chart.Series[i].Points[k].Color = colors[iSection];
				}
				
				i++; //series#
			}
		}
	}

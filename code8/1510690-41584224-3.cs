    class Plot
	{
		public Plot(List<Read> rrList, ComboBox xBox, ComboBox yBox, Chart chart) //***
		{
			int indX = xBox.SelectedIndex;
			int indY = yBox.SelectedIndex;
			chart.Series.Clear(); //ensure that the chart is empty
			chart.Legends.Clear();
			int i = 0; //series index
			foreach (Read rr in rrList)
			{
				float[,] data = rr.get_Data();
				int nLines = rr.get_nLines();
				int nColumns = rr.get_nColumns();
				string[] header = rr.get_Header();
				chart.Series.Add("Series" + i);
				chart.Series[i].ChartType = SeriesChartType.Line;
				chart.ChartAreas[0].AxisX.LabelStyle.Format = "{F2}";
				chart.ChartAreas[0].AxisX.Title = header[indX];
				chart.ChartAreas[0].AxisY.Title = header[indY];
				for (int j = 0; j < nLines; j++)
				{
					chart.Series[i].Points.AddXY(data[j, indX], data[j, indY]);
				}
				i++; //series index
			}
		}
	}

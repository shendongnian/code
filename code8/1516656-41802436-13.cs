	public class Plot
	{
		public static void Draw(Chart chart, List<Read> rList, int indX = 0, int indY = 1)
		{
			chart.Series.Clear(); //ensure that the chart is empty
			chart.Legends.Clear();
			Legend myLegend = chart.Legends.Add("myLegend");
			myLegend.Title = "myTitle";
			Color[] colors = new Color[] { Color.Black, Color.Blue, Color.Red, Color.Green, Color.Magenta, Color.DarkCyan, Color.Chocolate, Color.DarkMagenta }; 
			var sectionColors = new Dictionary<string, int>();
			bool separateSections = (rList.Count == 1); // #Edit: 4
			int i = 0;
			int iColor = -1, maxColor = -1;
			foreach (Read rr in rList)
			{
				float[,] data = rr.data;
				int nLines = rr.nLines;
				int nColumns = rr.nColumns;
				string[] header = rr.header;
				chart.Series.Add("Series" + i);
				chart.Series[i].ChartType = SeriesChartType.Line;
				chart.Series[i].LegendText = rr.fileName; // #Edit: 4
				if (separateSections) chart.Series[i].IsVisibleInLegend = false; // #Edit: 4
				chart.ChartAreas[0].AxisX.LabelStyle.Format = "{F2}";
				chart.ChartAreas[0].AxisX.Title = header[indX];
				chart.ChartAreas[0].AxisY.Title = header[indY];
				for (int j = 0; j < nLines; j++)
				{
					int k = chart.Series[i].Points.AddXY(data[j, indX], data[j, indY]);
					if (separateSections) // #Edit: 4
					{
						string curSection = rr.section[j];
						if (sectionColors.ContainsKey(curSection))
						{
							iColor = sectionColors[curSection];
						}
						else
						{
							maxColor++;
							iColor = maxColor; sectionColors[curSection] = iColor;
						}
						chart.Series[i].Points[k].Color = colors[iColor];
					}
				}
				i++; //series#
			} //end foreach rr
			//fill legend based on series
			foreach (var x in sectionColors)
			{
				string section = x.Key;
				iColor = x.Value;
				myLegend.CustomItems.Add(colors[iColor], section); //new LegendItem()
			}
		}
	}

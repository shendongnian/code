	public class Plot
	{
		//public Plot() { } //no constructor required as we use a static class to be called
		public static void Draw(List<Read> rrList, ComboBox xBox, ComboBox yBox, Chart chart) //***
		{
			int indX = xBox.SelectedIndex;
			int indY = yBox.SelectedIndex;
			chart.Series.Clear(); //ensure that the chart is empty
			chart.Legends.Clear();
			Legend myLegend = chart.Legends.Add("myLegend");
			myLegend.Title = "myTitle";
            //define a set of colors to be used for sections
			Color[] colors = new Color[] { Color.Black, Color.Blue, Color.Red, Color.Green, Color.Magenta, Color.DarkCyan, Color.Chocolate, Color.DarkMagenta }; 
			
			//use a Dictionary to keep iColor of each section
            // key=sectionName, value=iColor (color index in our colors array)
			var sectionColors = new Dictionary<string, int>();
			int i = 0;
			int iColor = -1, maxColor = -1;
			foreach (Read rr in rrList)
			{
				float[,] data = rr.data;
				int nLines = rr.nLines;
				int nColumns = rr.nColumns;
				string[] header = rr.header;
				chart.Series.Add("Series" + i);
				chart.Series[i].ChartType = SeriesChartType.Line;
				//chart.Series[i].LegendText = rr.fileName;
				chart.Series[i].IsVisibleInLegend = false; //hide default item from legend
				chart.ChartAreas[0].AxisX.LabelStyle.Format = "{F2}";
				chart.ChartAreas[0].AxisX.Title = header[indX];
				chart.ChartAreas[0].AxisY.Title = header[indY];
				for (int j = 0; j < nLines; j++)
				{
					int k = chart.Series[i].Points.AddXY(data[j, indX], data[j, indY]);
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
				i++; //series#
			} //end foreach rr
			//fill custom legends based on sections/colors
			foreach (var x in sectionColors)
			{
				string section = x.Key;
				iColor = x.Value;
				myLegend.CustomItems.Add(colors[iColor], section); //new LegendItem()
			}
		}
	}

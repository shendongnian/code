		void GetColourCodedSeries(ChartHelper chartHelper, DataTable table, string groupingColumn, string valueColumn)
		{
			List<Color> _palette = new List<Color>();
			
			var x = table.AsEnumerable().Select(f => f.Field<string>(groupingColumn)).ToArray();
			foreach (DataRow row in table.Rows)
			{
				if (Convert.ToDecimal(row[valueColumn].ToString()) >= _availabilityTarget) _palette.Add(Color.FromArgb(0, 176, 80));
				else _palette.Add(Color.FromArgb(139, 0, 0));
				
				List<decimal?> y = new List<decimal?>();
				foreach(var value in x)
				{
					if (value == row[groupingColumn].ToString()) y.Add(Convert.ToDecimal(row[valueColumn].ToString()));
					else y.Add(null);
				}
				chartHelper.AddSeries(SeriesChartType.Column, x, y, _palette.ToArray());
			}
		}

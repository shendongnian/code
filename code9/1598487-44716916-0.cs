		public IEnumerable<DateTime> DistinctDates
		{
			get
			{
				return from item in this.PricesView.Cast<Price>()
					   group item by item.List.EffectiveDate into g
					   select g.Key;
			}
		}
<ComboBox ItemsSource="{Binding DistinctDates}" />

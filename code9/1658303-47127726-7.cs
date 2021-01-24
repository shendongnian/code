    public static class GridExtensions
	{
        // Using a DependencyProperty as the backing store for ColumnDefinitions.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ColumnDefinitionsProperty =
			DependencyProperty.RegisterAttached(
				nameof(ColumnDefinitionsProperty).Substring(0, nameof(ColumnDefinitionsProperty).Length - "Property".Length),
				typeof(IEnumerable<ColumnDefinition>),
				typeof(GridExtensions),
				new PropertyMetadata(Enumerable.Empty<ColumnDefinition>(), ColumnDefinitionsChanged));
        public static IEnumerable<ColumnDefinition> GetColumnDefinitions(DependencyObject obj)
			=> (IEnumerable<ColumnDefinition>)obj.GetValue(ColumnDefinitionsProperty);
        public static void SetColumnDefinitions(DependencyObject obj, IEnumerable<ColumnDefinition> value)
			=> obj.SetValue(ColumnDefinitionsProperty, value);
        private static void ColumnDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var columnDefinitionCollection = ((Grid)d).ColumnDefinitions;
			var newColumnDefinitions = (IEnumerable<ColumnDefinition>)e.NewValue;
			var columnCount = newColumnDefinitions.Count();
			columnDefinitionCollection.Clear();
			foreach (var newColumnDefinition in newColumnDefinitions)
				columnDefinitionCollection.Add(newColumnDefinition);
		}
    }

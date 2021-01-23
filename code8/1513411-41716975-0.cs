	public class MyDataTemplateSelector : DataTemplateSelector
	{
		public DataTemplate SimpleTemplate { get; set; }
		public DataTemplate ComplexTemplate { get; set; }
		public MyDataTemplateSelector()
		{
			SimpleTemplate = new DataTemplate(typeof(SimpleView));
			ComplexTemplate = new DataTemplate(typeof(ComplexView));
		}
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			CustomCell cell = (CustomCell)item;
			if (cell.Testo.Length > 5) {
				return ComplexTemplate;
			} else {
				return SimpleTemplate;
			}
		}
	}

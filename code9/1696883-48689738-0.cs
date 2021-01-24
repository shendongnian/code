	internal class ParentViewModel : BindableBase
	{
		public ParentViewModel( ParentModel parentModel )
		{
			Children = new object[] { new TextViewModel(parentModel.TextProperty), new NumberViewModel(parentModel.NumberProperty) };
		}
		public IEnumerable Children { get; }
	}

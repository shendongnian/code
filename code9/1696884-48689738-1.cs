	internal class ParentViewModel : BindableBase
	{
		public ParentViewModel( ParentModel parentModel, IChildViewModelFactory factory )
		{
			Children = new object[] { factory.CreateTextViewModel(parentModel.TextProperty), factory.CreateNumberViewModel(parentModel.NumberProperty) };
		}
		public IEnumerable Children { get; }
	}

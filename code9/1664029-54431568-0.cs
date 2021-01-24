    public class WindowDialogService : IWindowDialogService
        {
            private static readonly Dictionary<Type, Type> viewModelPairs =
                new Dictionary<Type, Type>
                {
                    [typeof(DetailsViewModel)] = typeof(DetailsView)
                };
    
            public void ShowWindowDialog(IViewModelBase viewModel)
            {
                if (!viewModelPairs.TryGetValue(viewModel.GetType(), out Type viewType))
                {
                    throw new ArgumentException("View Model not mapped", nameof(viewModel));
                }
    
                if (viewType.GetConstructor(Type.EmptyTypes).Invoke(new object[] { }) is Window view)
                {
                    view.DataContext = viewModel;
                    view.Owner = Application.Current.MainWindow;
                    view.ShowDialog();
                }
            }
        }

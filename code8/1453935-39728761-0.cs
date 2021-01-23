    public class MyViewModel
    {
        public MyModel Model {/*get... set*/}
        public ObservableCollection<StepViewModel> Steps {/*get... set...*/}
        public StepViewModel SelectedStep {/*get... set...*/}
        public MyViewModel()
        {
            Model = new MyModel();
            Steps = new ObservableCollection<StepViewModel>();
            Model.Steps = new ObservableCollection<StepModel>();
            // Load the saved Model with the steps and their positions
            Model.Steps = LoadFromXml();
            Steps.CollectionChanged += Steps_OnCollectionChanged;
            // Add the Steps in the right order
            for (int i = 0; i < Steps.Count; i++)
            {
                 var item = Steps.First(x => x.Position == i);
                 var vm = new StepViewModel();
                 Steps.Add(vm);
            }
        }
    
        private void Steps_OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (StepViewModel vm in e.NewItems)
                {
                    if (!Model.Steps.Contains(vm.Model))
                        Model.Steps.Add(vm.Model);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (StepViewModel vm in e.OldItems)
                {
                    if (Model.Steps.Contains(vm.Model))
                        Model.Steps.Remove(vm.Model);
                }
            }
            // Match the temporary collectionindex to a position-property
            foreach (StepViewModel item in Steps)
            {
                item.Position = Steps.IndexOf(item);
            }
        }
    }

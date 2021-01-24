    public class ChooseMachineViewModel : ReactiveObject
    {
        public IReactiveDerivedList<Button> ButtonList { get; set; }
        public ChooseMachineViewModel(ObservableCollection<CUStatus> source)
        {
            addressToButton = new Dictionary<ushort, Button>();
            ButtonList = ControlUnitsStatus.CreateDerivedCollection(status => new Button { Content = status.Address.ToString() },
                                                        status => !ButtonList.Any(button => button.Content.ToString().Equals(status.Address.ToString())));
        }
    }

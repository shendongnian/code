    //MEF IoC Container -- CM Built-in
    [Export(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : Conductor<IScreen>.Collection.OneActive
    {
        [ImportingConstructor]
        public MainWindowViewModel([ImportMany]IEnumerable<IScreen> screens)
        {
            DisplayName = "COmposition Example - CM";
            Items.AddRange(screens.Reverse());
        }
        protected override void OnActivate()
        {
            ActivateItem(Items[0]);
        }
    }

    public class FirstModel : ModelBase
    {
         public String FirstValue { get; set; }
         public String SecondValue { get; set; }
    }
    public class FirstViewModel : ViewModelBase
    {
         private readonly IFirstService _firstService;
         public FirstViewModel(IFirstService firstService)
             : this(new First(), firstService)
         {
         }
         public FirstViewModel(First first, IFirstService firstService)
         {
             Argument.IsNotNull(() => first);
             Argument.IsNotNull(() => firstService);
             _firstService = firstService;
             First = first;
             WriteFirst = new Command(OnWriteFirstExecute);
         }
         [Model]
         // you can use ExposeAttribute if you don't want to use 'FirstValue'
         // property inside of ViewModel and only want to use it for binding
         [Expose(nameof(FirstModel.FirstValue))]
         public FirstModel First { get; set; }
         [ViewModelToModel(nameof(First)]
         public String SecondValue { get; set; }
         public Command WriteFirst { get; }
         private void OnWriteFirstExecute()
         {
             // here you can put you logic (not sure what you want to achieve)
             // _firstService.Write()
         }
    }

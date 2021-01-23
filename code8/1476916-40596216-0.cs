    public class FirstModel : ModelBase
    {
         public String FirstValue { get; set; }
         public String SecondValue { get; set; }
    }
    public class FirstViewModel : ViewModelBase
    {
         public FirstViewModel(First first)
         {
             Argument.IsNotNull(() => first);
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
             First.FirstValue = SecondValue;
             // or
             // SecondValue = First.FirstValue
         }
    }

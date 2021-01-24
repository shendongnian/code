    public partial class ComoChegarView
    {
       ...
       private List<Localizacao> Locals{get;set;}       
       public ComoChegarView(List<Localizacao> locals)
       {
          InitializeComponent(); //standard code that mix xaml and code behind
          this.Locals = locals; //store the data in property
          this.BindingContext = this; //Set the binding context
       }
    
    }

    private Entry _urlEntry = new Entry { Placeholder = "url" };
    private Button _submit = new Button { Text = "Submit" };
    private Model _model;
    
    public BackPage()
    {
       Content = new StackLayout
       {
          Children = { _urlEntry, _submit }
       };
          _submit.Clicked += Submit_Clicked;
     }
